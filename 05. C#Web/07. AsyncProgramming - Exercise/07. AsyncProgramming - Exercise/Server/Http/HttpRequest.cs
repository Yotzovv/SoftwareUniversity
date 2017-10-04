﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

public class HttpRequest : IHttpRequest
{
    
    public HttpRequest(string requestString)
    {
        CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));
        this.FormData = new Dictionary<string, string>();
        this.Headers = new HttpHeaderCollection();
        this.UrlParameters = new Dictionary<string, string>();
        this.QueryParameters = new Dictionary<string, string>();

        this.ParseRequest(requestString);
    }


    public IDictionary<string, string> FormData { get; private set; }

    public HttpHeaderCollection Headers { get; private set; }

    public string Path { get; private set; }

    public IDictionary<string, string> QueryParameters { get; private set; }

    public HttpRequestMethod Method { get; private set; }

    public string Url { get; private set; }

    public IDictionary<string, string> UrlParameters { get; private set; }

    public void AddUrlParameter(string key, string value)
    {
        CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
        CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

        this.UrlParameters[key] = value;
    }

    private void ParseRequest(string requestString)
    {
        var tokens = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        if(!tokens.Any())
        {
            BadRequestException.ThrowFromInvalidRequest();
        }

        var requestLine = tokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
        {
            BadRequestException.ThrowFromInvalidRequest();
        }

        this.Method = this.ParseMethod(requestLine[0]);
        this.Url = tokens[1];
        this.Path = this.ParsePath(Url);
        this.ParseHeaders(tokens);
        this.ParseParameters();
        this.ParseFormData(tokens.Last());
    }

    private void ParseFormData(string formDataLine)
    {
        if(this.Method == HttpRequestMethod.Get)
        {
            return;
        }
        
        this.ParseQuery(formDataLine, this.QueryParameters);
    }

    private void ParseParameters()
    {
        if(!this.Url.Contains('?'))
        {
            return;
        }

        var query = this.Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries).Last();

        this.ParseQuery(query, this.UrlParameters);
    }

    private void ParseQuery(string query, IDictionary<string, string> dict)
    {        
        if (!query.Contains('='))
        {
            return;
        }

        var queryPairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var queryPair in queryPairs)
        {
            var queryKvp = queryPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (queryKvp.Length != 2)
            {
                return;
            }

            var queryKey = WebUtility.UrlDecode(queryKvp[0]);
            var queryValue = WebUtility.UrlDecode(queryKvp[1]);

            dict.Add(queryKey, queryValue);
        }
    }

    private void ParseHeaders(string[] tokens)
    {
        var emptyLineAfterHeadersIndex = Array.IndexOf(tokens, string.Empty);

        for (int i = 1; i < tokens.Length; i++)
        {
            var currentLine = tokens[i];
            var headerParts = currentLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

            if(headerParts.Length != 2)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            var headerKey = headerParts[0];
            var headerValue = headerParts[1].Trim();
            this.Headers.Add(new HttpHeader(headerKey, headerValue));
        }

        if(!this.Headers.ContainsKey("Host"))
        {
            BadRequestException.ThrowFromInvalidRequest();
        }
    }



    private string ParsePath(string url)
    {
        return url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
    }

    private HttpRequestMethod ParseMethod(string method)
    {
        HttpRequestMethod parsedMethod;

        if (Enum.TryParse<HttpRequestMethod>(method, false, out parsedMethod))
        {
            BadRequestException.ThrowFromInvalidRequest();
        }

        return parsedMethod;
    }
}
