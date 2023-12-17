using BlazorCRUDAppDotNet8.Client.Services;
using BlazorCRUDAppDotNet8.Shared.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IDevelopersRepository, DeveloperService>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});


await builder.Build().RunAsync();
