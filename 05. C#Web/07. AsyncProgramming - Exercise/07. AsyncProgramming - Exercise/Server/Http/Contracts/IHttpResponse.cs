public interface IHttpResponse
{
    HttpStatusCode StatusCode { get; }

    IHttpHeaderCollection Headers { get; } 

    IHttpCookieCollection Cookies { get; }
}

