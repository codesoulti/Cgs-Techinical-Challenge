using Cgs.Techinical.Challenge.Domain.Shared.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cgs.Technical.Challenge.Domain.Shared.Http
{
    public class HttpResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var currentBody = context.Response.Body;
            
            try
            {
                using var memoryStream = new MemoryStream();
                context.Response.Body = memoryStream;
                context.Response.ContentType = "application/json";

                await _next(context);

                context.Response.Body = currentBody;

                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = await new StreamReader(memoryStream).ReadToEndAsync();

                if (context.Response.StatusCode == 200 && !context.Response.HasStarted)
                {
                    var result = JsonConvert.DeserializeObject(readToEnd);

                    var response = new HttpResponse<object>
                    {
                        Success = true,
                        Result = result,
                        StatusCode = context.Response.StatusCode,
                        Error = null
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response,
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }
                    ));
                }
            }
            finally
            {
                context.Response.Body = currentBody;
            }
        }
    }
}
