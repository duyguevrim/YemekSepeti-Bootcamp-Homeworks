using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefreshToken.Context;
using RefreshToken.Models;
using RefreshToken.Services;
using System.Threading.Tasks;

namespace RefreshToken.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private readonly HotelApiDbContext _dbContext;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]

        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] TokenRequest req)
        {
            if (req == null)
                return BadRequest();

            var result = await _userService.Authenticate(req);
            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {

            if (refreshToken == null)
                return BadRequest();

            var response = await _userService.RefreshToken(refreshToken);
            if (response == null)
                return Unauthorized();



            return Ok(response);
        }

    }
}
