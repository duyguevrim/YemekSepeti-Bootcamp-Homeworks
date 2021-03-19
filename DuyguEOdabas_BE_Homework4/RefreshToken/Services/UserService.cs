using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.Tokens;
using RefreshToken.Context;
using RefreshToken.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RefreshToken.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly HotelApiDbContext _dbContext;
        private IConfiguration _configuration;

        public UserService(HotelApiDbContext dbContext,
                           IMapper mapper,
                           IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<UserInfo> Authenticate(TokenRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.LoginUser) ||
               string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            var user = await _dbContext
                             .Users
                             .SingleOrDefaultAsync(user => user.LoginName == req.LoginUser &&
                                                           user.Password == req.LoginPassword);

            if (user == null)
                return null;

            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDesc = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.Name, user.Id.ToString())
               }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var newToken = tokenHandler.CreateToken(tokenDesc);

            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.ExpireTime = tokenDesc.Expires ?? DateTime.Now.AddHours(1);
            userInfo.Token = tokenHandler.WriteToken(newToken);
            userInfo.RefreshToken = CreateRefreshToken();
            userInfo.RefreshTokenEndTime = DateTime.Now.AddHours(1.5);
            _dbContext.UserInfos.Add(userInfo);
            await _dbContext.SaveChangesAsync();
            return userInfo;
        }

        public Task<UserInfo> Authenticate(TokenRequest req)
        {
            throw new NotImplementedException();
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
        public async Task<UserInfo> RefreshToken(string refreshToken)
        {
            UserInfo user = await _dbContext.UserInfos.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                var secretKey = _configuration.GetValue<string>("JwtTokenKey");
                var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var tokenDesc = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new Claim[]
                   {
                   new Claim(ClaimTypes.Name, user.Id.ToString())
                   }),
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var newToken = tokenHandler.CreateToken(tokenDesc);


                user.ExpireTime = tokenDesc.Expires ?? DateTime.Now.AddHours(1);
                user.Token = tokenHandler.WriteToken(newToken);
                user.RefreshToken = CreateRefreshToken();
                user.RefreshTokenEndTime = DateTime.Now.AddHours(1.5);
                _dbContext.UserInfos.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            return null;
        }

        Task<UserInfo> IUserService.RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
