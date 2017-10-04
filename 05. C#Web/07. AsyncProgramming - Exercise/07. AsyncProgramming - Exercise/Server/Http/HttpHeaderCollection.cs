using System;
using System.Collections;
using System.Collections.Generic;

public class HttpHeaderCollection : IHttpHeaderCollection
{
    private readonly IDictionary<string, HttpHeader> headers;

    public HttpHeaderCollection()
    {
        headers = new Dictionary<string, HttpHeader>();
    }

    public void Add(HttpHeader header)
    {
        CoreValidator.ThrowIfNull(header, nameof(header));

        headers[header.Key] = header;
    }

    public bool ContainsKey(string key)
    {
        CoreValidator.ThrowIfNull(key, nameof(key));

        return this.headers.ContainsKey(key);
    }

    public HttpHeader Get(string key)
    {
        CoreValidator.ThrowIfNull(key, nameof(key));

        if(!this.headers.ContainsKey(key))
        {
            throw new InvalidOperationException($"The given key {key} is not present in the headers collection.");
        }

        return this.headers[key];
    }

    public override string ToString() => string.Join(Environment.NewLine, this.headers);
}
