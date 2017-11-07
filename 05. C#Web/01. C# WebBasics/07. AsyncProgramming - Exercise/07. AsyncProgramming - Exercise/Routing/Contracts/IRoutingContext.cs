using System.Collections;
using System.Collections.Generic;

public interface IRoutingContext
{
    IEnumerable<string> Parameters { get; }

    RequestHandler RequestHandler { get; }
}
