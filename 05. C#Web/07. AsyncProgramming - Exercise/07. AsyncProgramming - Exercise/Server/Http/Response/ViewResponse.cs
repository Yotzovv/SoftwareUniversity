using System;

public class ViewResponse : HttpResponse
{
    private readonly IView view;
    
    public ViewResponse(HttpStatusCode statusCode, IView view)
    {
        this.ValidateStatusCode(statusCode);

        this.view = view;
        this.StatusCode = statusCode;

        this.Headers.Add("Content-Type", "text/html");
    }

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
