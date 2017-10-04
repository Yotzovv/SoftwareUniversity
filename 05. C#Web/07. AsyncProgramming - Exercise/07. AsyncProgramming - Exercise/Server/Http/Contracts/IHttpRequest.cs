using System.Collections;
using System.Collections.Generic;

public interface IHttpRequest
{
    IDictionary<string, string> FormData { get; }

    HttpHeaderCollection Headers { get; }

    string Path { get; }

    IDictionary<string, string> QueryParameters { get; }

    IDictionary<string, string> UrlParameters { get; }

    HttpRequestMethod Method { get; }

    string Url { get; }

    void AddUrlParameter(string key, string value);    
}

