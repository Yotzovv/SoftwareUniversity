using System.Collections.Generic;

public interface IServerRouteConfig
{
    IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }
}