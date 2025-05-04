using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using VersionOneWA.Client;
using VersionOneWA.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.openweathermap.org/") });
builder.Services.AddScoped<WeatherService>(); //registracia api k pocasiu

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddScoped<IFriendshipService>(sp =>
    new ClientFriendshipService(sp.GetRequiredService<HttpClient>()));



builder.Services.AddScoped<IJobServices, ClientJobService>();
builder.Services.AddScoped<IBeehiveService, ClientBeehiveService>();
builder.Services.AddScoped<IStatusServices, ClientStatusService>();
builder.Services.AddScoped<IFriendshipService, ClientFriendshipService>();
builder.Services.AddScoped<IFriendService, ClientFriendService>();
//
//builder.Services.AddScoped<IBeehiveBaseService, ClientBeehiveBaseService>();

builder.Services.AddMudServices();


await builder.Build().RunAsync();
