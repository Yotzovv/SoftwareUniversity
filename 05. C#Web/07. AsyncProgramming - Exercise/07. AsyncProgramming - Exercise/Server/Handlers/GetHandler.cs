using System;

public class GetHandler : RequestHandler
{
    public GetHandler(Func<IHttpRequest, IHttpResponse> handlingFunc) : base(handlingFunc)
    {

    }
}

