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
        string sessionIdToSend = null;

        if (!context.Request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
        {
            var sessionId = Guid.NewGuid().ToString();
            
            context.Request.Session = SessionStore.Get(sessionId);

            sessionIdToSend = sessionId;
        }

        var response = this.handlingFunc(context.Request);
        
        if(sessionIdToSend != null)
        {
            response.Headers.Add(HttpHeader.SetCookie,
                $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
        }

        var httpHeader = new HttpHeader("Content-Type", "text/html");

        if (!response.Headers.ContainsKey(httpHeader.Key))
        {
            response.Headers.Add(HttpHeader.ContentType, "text/plain");
        }

        foreach (var cookie in response.Cookies)
        {
            response.Headers.Add(HttpHeader.SetCookie, cookie.ToString());
        }

        return response;
    }
}
