class HomeController
{
    public IHttpResponse Index()
    {
        return new ViewResponse(HttpStatusCode.OK, new IndexView());
    }
}
