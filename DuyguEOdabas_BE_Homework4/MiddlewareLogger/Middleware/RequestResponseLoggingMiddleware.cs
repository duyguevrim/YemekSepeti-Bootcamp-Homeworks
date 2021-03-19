using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLogger
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("TASK INVOKE");
            var request = await FormatRequest(context.Request);

            var originalBodyStream = context.Response.Body;

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            var response = await FormatResponse(context.Response);


            await responseBody.CopyToAsync(originalBodyStream);
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            Console.WriteLine("TASK FormatRequest");
            var body = request.Body;

            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length)).ConfigureAwait(false);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            var path = @"C:\Users\duyguevrim\source\repos\YemekSepeti_Hw4\MiddlewareLogger\request.txt";

            using var sw = new StreamWriter(path, true);

            var data = $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
            sw.WriteLine(DateTime.Now.ToString() + " : " + data);
            Console.WriteLine($"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}");
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private static async Task<string> FormatResponse(HttpResponse response)
        {
            Console.WriteLine("TASK FormatResponse");
            response.Body.Seek(0, SeekOrigin.Begin);

            string text = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            var path = @"C:\Users\duyguevrim\source\repos\YemekSepeti_Hw4\MiddlewareLogger\response.txt";
            using var sw = new StreamWriter(path, true);
            var data = $"{response.StatusCode}: {text}";
            sw.WriteLine(DateTime.Now.ToString() + " : " + data);
            Console.WriteLine($"{response.StatusCode}: {text}");
            return $"{response.StatusCode}: {text}";
        }
    }
}
