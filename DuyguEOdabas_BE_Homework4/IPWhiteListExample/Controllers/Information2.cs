using IPWhiteListExample.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPWhiteListExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(IpControlAttribute))]
    public class Information2
    {

        [HttpGet("[action]")]
        public string Get()
        {
            return "duygu evrim odabas 2 ";
        }

        [HttpGet("[action]")]
        public string GetControllerInfo()
        {
            return "Information2";
        }
    }
}
