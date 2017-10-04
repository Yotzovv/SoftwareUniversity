public class NotFoundResponse : IHttpResponse
{
    public NotFoundResponse()
    {
    }

    public HttpStatusCode StatusCode { get; }

    public HttpHeaderCollection Headers { get; }
}
