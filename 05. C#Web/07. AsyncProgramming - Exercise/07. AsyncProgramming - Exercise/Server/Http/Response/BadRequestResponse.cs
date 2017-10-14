public class BadRequestResponse : HttpResponse
{
    public BadRequestResponse()
    {
        this.StatusCode = HttpStatusCode.BadRequest;
    }
}
