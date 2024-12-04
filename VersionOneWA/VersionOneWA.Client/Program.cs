using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VersionOneWA.Client;
using VersionOneWA.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});


builder.Services.AddScoped<IJobServices, ClientJobService>();


await builder.Build().RunAsync();
