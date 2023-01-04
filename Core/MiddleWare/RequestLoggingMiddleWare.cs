using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MiddleWare
{
    public class RequestLoggingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleWare(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleWare>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Request {method}  -  {url} => {statusCode}   invoked",
                                 context.Request?.Method,
                                 context.Request?.Path.Value,
                                 context.Response?.StatusCode);


            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            finally
            {
                var originalBodyStream = context.Response.Body;
                var ReqText = await FormatRequest(context.Request);
                var RspText = "";

                using (var responseBody = new MemoryStream())
                {
                    try
                    {
                        context.Response.Body = responseBody;
                        await _next(context);
                        RspText = await FormatResponse(context?.Response);
                        await responseBody.CopyToAsync(originalBodyStream);
                    }
                    catch (Exception ex)
                    {
                        await HandleExceptionAsync(context, ex);
                    }


                    // log 
                    _logger.LogInformation($"Request= {ReqText}  - Response= {RspText} ");
                }
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var bodyAsText = "";
            try
            {
                using (var bodyReader = new StreamReader(request.Body))
                {
                    bodyAsText = await bodyReader.ReadToEndAsync();
                    request.Body = new MemoryStream(Encoding.UTF8.GetBytes(bodyAsText));
                }
            }
            catch (Exception ex)
            {

            }

            return $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString} {bodyAsText}";
        }
        private async Task<string> FormatResponse(HttpResponse response)
        {
            var sr = new StreamReader(response.Body);
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await sr.ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"Response {text}";
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            _logger.LogError($"{DateTime.Now.ToString("HH:mm:ss")} : {ex}");
            return Task.CompletedTask;
        }

    }
}
