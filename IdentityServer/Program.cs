using IdentityServer;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
 .AddInMemoryClients(Config.Clients)
 .AddInMemoryApiScopes(Config.ApiScopes)
 .AddInMemoryIdentityResources(Config.IdentityResources)
 //.AddInMemoryApiResources(Config.ApiResources)
 .AddTestUsers(Config.TestUsers)
 .AddDeveloperSigningCredential();

var app = builder.Build();
//app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseIdentityServer();

app.Run();
