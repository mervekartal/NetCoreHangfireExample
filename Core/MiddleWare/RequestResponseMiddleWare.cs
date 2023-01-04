using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.MiddleWare
{
    public class RequestResponseMiddleWare
    {
        private readonly RequestDelegate next;

        public RequestResponseMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext context)
        {

           
            if (context.Request.Method =="GET" && context.Request.Path == "/api/Vehicle/GetById")
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                string message = "Access Denied";
                var result = JsonConvert.SerializeObject(new { Errormessage = message }, Formatting.None);

                await context.Response.WriteAsync(result);
                return;
            }

            // do job 
            await next.Invoke(context);
        }
    }
}
