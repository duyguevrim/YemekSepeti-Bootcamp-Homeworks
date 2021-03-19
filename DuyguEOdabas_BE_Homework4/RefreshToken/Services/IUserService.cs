using RefreshToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshToken.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
        string CreateRefreshToken();
        Task<UserInfo> RefreshToken(string refreshToken);
    }
}
