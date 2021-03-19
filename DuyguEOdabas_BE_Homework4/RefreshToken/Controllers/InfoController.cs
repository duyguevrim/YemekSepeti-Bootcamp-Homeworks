using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RefreshToken.Models.Derived;

namespace RefreshToken.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly HotelInfo _hotelInfo;

        public InfoController(IOptions<HotelInfo> hotleInfoOption)
        {
            _hotelInfo = hotleInfoOption.Value;
        }

        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfo> GetInfo()
        {
            _hotelInfo.Href = Url.Link(nameof(GetInfo), null);
            return _hotelInfo;
        }

    }
}
