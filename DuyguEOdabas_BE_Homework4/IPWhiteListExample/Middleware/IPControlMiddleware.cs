using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IPWhiteListExample.Middleware
{
    public class IPControlMiddleware
    {
        readonly RequestDelegate _next;
        IConfiguration _configuration;
        public IPControlMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            IPAddress remoteIp = context.Connection.RemoteIpAddress;
            var ips = _configuration.GetSection("WhiteList").AsEnumerable().Where(ip => !string.IsNullOrEmpty(ip.Value)).Select(ip => ip.Value).ToList();

            if (!ips.Where(ip => IPAddress.Parse(ip).Equals(remoteIp)).Any())
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("erişim yetkisi yoktur....");
                return;
            }

            await _next.Invoke(context);
        }
    }
}
