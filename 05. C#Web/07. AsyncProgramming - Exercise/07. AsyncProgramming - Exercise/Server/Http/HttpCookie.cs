using System;

public class HttpCookie
{
    public HttpCookie(string key, string value, int expires = 3)
    {
        CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
        CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

        this.Key = key;
        this.Value = value;
        this.Expires = DateTime.UtcNow.AddDays(expires);
    }

    public HttpCookie(string key, string value, bool isNew, int expires = 3)
        : this(key, value, expires)
    {
        this.isNew = isNew;
    }

    public string Key { get; private set; }

    public string Value { get; private set; }

    public DateTime Expires { get; private set; }

    public bool isNew { get; private set; } = true;



    public override string ToString()
    {
        return $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";   
    }
}