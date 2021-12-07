using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace WindowsServiceAPI
{
    public interface IRoutable
    {
        void ConfigureRoutes(IEndpointRouteBuilder route);
    }
    
    public class HelloWorld : IRoutable
    {
        public void ConfigureRoutes(IEndpointRouteBuilder route)
        {
            route.MapGet("/1", async context =>
            {
                route.ResolveDependency<DoStuff>().Print();
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hi there asdlfj"));
            });

            route.MapGet("/2", async context =>
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("This is something."));
            });
            
            route.MapGet("/3", async context =>
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(context.Request.Path));
            });
        }
    }
}