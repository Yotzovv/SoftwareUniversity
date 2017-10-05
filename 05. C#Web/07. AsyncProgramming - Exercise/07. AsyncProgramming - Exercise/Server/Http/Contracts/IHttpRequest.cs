using System.Collections;
using System.Collections.Generic;

public interface IHttpRequest
{
    IDictionary<string, string> FormData { get; }

    IHttpHeaderCollection Headers { get; }

    IHttpCookieCollection Cookies { get; }

    IHttpSession Session { get; set; }

    IDictionary<string, string> QueryParameters { get; }

    IDictionary<string, string> UrlParameters { get; }
    
    HttpRequestMethod Method { get; }

    string Path { get; }

    string Url { get; }

    void AddUrlParameter(string key, string value);    
}
