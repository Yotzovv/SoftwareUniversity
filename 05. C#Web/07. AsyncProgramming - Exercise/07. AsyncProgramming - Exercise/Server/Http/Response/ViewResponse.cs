using System;

public class ViewResponse : IHttpResponse
{
    private readonly IView view;
    
    public ViewResponse(HttpStatusCode statusCode, IView view)
    {
        this.ValidateStatusCode(statusCode);
        this.view = view;
        this.StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; }

    public HttpHeaderCollection Headers { get; }

    private void ValidateStatusCode(HttpStatusCode statusCode)
    {
        var statusCodeNumber = (int)statusCode;

        if (299 < statusCodeNumber && statusCodeNumber < 400)
        {
            throw new InvalidResponseException("View response need a status code between bellow 300 or above 400");
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.view.View()}";
    }
}
