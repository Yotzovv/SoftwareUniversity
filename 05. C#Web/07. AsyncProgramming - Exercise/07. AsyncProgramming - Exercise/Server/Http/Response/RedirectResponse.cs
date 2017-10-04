public class RedirectResponse : HttpResponse
{
    public RedirectResponse(string redirectUrl)
    {
        CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

        this.StatusCode = HttpStatusCode.Found;
        this.Headers.Add(new HttpHeader("Location", redirectUrl));
    }
}
