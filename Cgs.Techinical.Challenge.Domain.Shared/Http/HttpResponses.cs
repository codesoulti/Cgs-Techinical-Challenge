using Microsoft.AspNetCore.Http;

namespace Cgs.Techinical.Challenge.Domain.Shared.Http
{
    public class HttpResponse<T>
    {
        public T? Result { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Error { get; set; }
    }

    public class HttpResponseError
    {
        public int StatusCode { get; set; }
        public string? Error { get; set; }
    }
}
