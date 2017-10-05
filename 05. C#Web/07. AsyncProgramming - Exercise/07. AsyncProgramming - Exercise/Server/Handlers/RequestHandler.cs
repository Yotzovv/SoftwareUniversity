using System;

public class RequestHandler : IRequestHandler
{
    private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

    public RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
    {
        CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));

        this.handlingFunc = handlingFunc;
    }
    
    public IHttpResponse Handle(IHttpContext context)
    {
        var response = this.handlingFunc(context.Request);
        HttpHeader httpHeader = new HttpHeader("Content-Type", "text/html");

        if (!response.Headers.ContainsKey(httpHeader.Key))
        {
            response.Headers.Add(httpHeader);
        }

        return response;
    }
}
