using System;

public class GameStoreHomeController
{
    public IHttpResponse Index()
    {
        var response = new ViewResponse(HttpStatusCode.OK, new IndexView());

        response.Cookies.Add(new HttpCookie("lang", "en"));

        return response;
    }

    public IHttpResponse SessionTest(IHttpRequest request)
    {
        var session = request.Session;

        const string sessionDateKey = "saved_date";

        if(session.Get(sessionDateKey) == null)
        {
            session.Add(sessionDateKey, DateTime.UtcNow);
        }

        return new ViewResponse(HttpStatusCode.OK, 
            new SessionTestView(session.Get<DateTime>(sessionDateKey)));
    }
}
