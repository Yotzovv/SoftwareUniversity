using CameraBazaar.Services.Generics;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace CameraBazaar.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly.GetAssembly(typeof(IService))
                    .GetTypes()
                    .Where(x => x.IsClass && x.GetInterfaces().Any(i => i.Name == $"I{x.Name}"))
                    .Select(x => new
                    {
                        Interface = x.GetInterface($"I{x.Name}"),
                        Implementation = x
                    })
                    .ToList()
                    .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }
    }
}
