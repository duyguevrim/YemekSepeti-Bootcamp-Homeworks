using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IPWhiteListExample.Attributes
{
    public class IpControlAttribute : ActionFilterAttribute
    {
        
        IConfiguration _configuration;
        public IpControlAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IPAddress remoteIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4();

            var ips = _configuration.GetSection($"WhiteList:{remoteIp}").AsEnumerable().
                Where(ip => !string.IsNullOrEmpty(ip.Value)).
                Select(ip => ip.Value).ToList();

            if (!ips.Where(path => path == context.RouteData.Values["controller"].ToString()).Any())
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                return;
            }
            base.OnActionExecuting(context);
        }
    
}
    }