using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



// DENEME AMAÇLI YAPILDI, KULLANILMIYOR

namespace Versioning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class VersionController : ControllerBase
    {

        [HttpGet(Name = nameof(GetCustomers))]
        public IActionResult GetCustomers()
        {
            List<string> customers = new List<string>()
            {
                "Duygu Evrim Odabaş",
                "Gonca Ecrin Odabaş"
            };

            return Ok(customers); 
        }

        [ApiVersion("1.0", Deprecated = true)]
        [MapToApiVersion("1.1")]
        [HttpGet(Name = nameof(GetCustomerV2))]
        public IActionResult GetCustomerV2()
        {
            List<string> customers = new List<string>()
            {
                "Duygu",
                "Gonca"
            };

            return Ok(customers);
        }


    }
}
