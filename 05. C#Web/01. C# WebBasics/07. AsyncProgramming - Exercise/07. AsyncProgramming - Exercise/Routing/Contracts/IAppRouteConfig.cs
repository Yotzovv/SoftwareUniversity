using System;
using System.Collections.Generic;

public interface IAppRouteConfig
{
    IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes
    {
        get;
    }

    ICollection<string> AnonymousPaths { get; }

    void AddRoute(string route, HttpRequestMethod method, RequestHandler httpHandler);

    void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

    void Post(string route, Func<IHttpRequest, IHttpResponse> handler);
}

