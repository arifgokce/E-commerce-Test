using Hepsiburada.Entities.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Api.Exception
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, System.Exception ex)
        {
            Response<string> result = new Response<string>();

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //To-do log yazilacak, hata mesajlari siniflandirilabilir.
            result.Message = ex.Message;
            if (ex.HResult>0)
            {
                result.ResultCode = ex.HResult.ToString();
            }
            string jsonModel = JsonConvert.SerializeObject(result);
            await httpContext.Response.WriteAsync(jsonModel);
        }
      
    }
}
