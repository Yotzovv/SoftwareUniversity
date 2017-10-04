using System.Collections.Generic;

public class RoutingContext : IRoutingContext
{
    private RequestHandler value;
    private List<string> args;

    public RoutingContext()
    {
    }

    public RoutingContext(RequestHandler value, List<string> args)
    {
        this.value = value;
        this.args = args;
    }

    public IEnumerable<string> Parameters { get; private set; }

    public RequestHandler RequestHandler { get; }
}
