using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WindowsServiceAPI
{
    public abstract class BaseRouteHandler
    {
        public BaseRouteHandler(IEndpointRouteBuilder routeBuilder)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            ConfigureEndpoints(routeBuilder);
        }
        
        public abstract void ConfigureEndpoints(IEndpointRouteBuilder endpoint);
    }

    public static class WebApplicationExtensions
    {
        public static T ResolveDependency<T>(this IEndpointRouteBuilder routeBuilder)
        {
            return routeBuilder.ServiceProvider.GetRequiredService<T>();
        }
        public static void MapRoutes<T>(this WebApplication application) where T : IRoutable, new()
        {
            new T().ConfigureRoutes(application);
        }
        
        public static T Resolve<T>(this WebApplication webApplication) where T : class
        {
            return webApplication.Services.GetService<T>();
        }
    }
}