//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();
//app.Run();
using Ocelot.Provider.Eureka;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration).AddEureka();
var app = builder.Build();
await app.UseOcelot();


app.Run();
