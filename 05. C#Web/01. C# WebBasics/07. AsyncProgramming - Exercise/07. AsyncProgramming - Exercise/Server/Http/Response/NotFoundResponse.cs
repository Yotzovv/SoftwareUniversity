public class NotFoundResponse : HttpResponse
{
    public NotFoundResponse()
    {
        this.StatusCode = HttpStatusCode.NotFound;
    }
}
