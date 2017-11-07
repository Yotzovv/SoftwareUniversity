public interface IRequestHandler
{
    IHttpResponse Handle(IHttpContext httpContext);
}
