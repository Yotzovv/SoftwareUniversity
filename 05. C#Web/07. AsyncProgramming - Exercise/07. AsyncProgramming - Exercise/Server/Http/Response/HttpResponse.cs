using System.Text;

public abstract class HttpResponse
{
    private string StatusCodeMessage => this.StatusCode.ToString();

    protected HttpResponse()
    {
        this.Headers = new HttpHeaderCollection();
    }
    
    public HttpHeaderCollection Headers { get; }

    public HttpStatusCode StatusCode { get; protected set; }
    
    public override string ToString()
    {
        var response = new StringBuilder();

        var statusCodeNumber = (int)this.StatusCode;

        response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusCodeMessage}");
        response.AppendLine(this.Headers.ToString());
        response.AppendLine();

        return response.ToString();
    }
}
