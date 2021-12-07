using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WindowsServiceAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureServices((_, collection) =>
{
    collection.AddHostedService<Worker>();
});

builder.Services.AddTransient<DoStuff, DoStuff>();

builder.Host.UseWindowsService();
var app = builder.Build();

app.MapRoutes<HelloWorld>();
app.Run();