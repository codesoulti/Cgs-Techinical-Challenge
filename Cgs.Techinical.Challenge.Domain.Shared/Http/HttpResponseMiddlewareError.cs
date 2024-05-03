using Cgs.Techinical.Challenge.Domain.Shared.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cgs.Technical.Challenge.Domain.Shared.Http
{
    public class HttpResponseMiddlewareError
    {
        private readonly RequestDelegate _next;
        public HttpResponseMiddlewareError(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpRequestException ex)
            {
                await HandleRequestExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleRequestExceptionAsync(context, ex);
            }
        }

        private static async Task HandleRequestExceptionAsync(HttpContext context, dynamic ex)
        {
            context.Response.ContentType = "application/json";
            var statusCode = 500;
           
            if (ex.GetType().IsAssignableFrom(typeof(BadHttpRequestException)))
            {
                statusCode = ex.StatusCode;
            }

            var response = new HttpResponseError
            {
                StatusCode = statusCode,
                Error = ex.Message
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response,
                   new JsonSerializerSettings
                   {
                       ContractResolver = new CamelCasePropertyNamesContractResolver()
                   }
               ));
        }
    }
}
