using Microsoft.AspNetCore.Authentication.Cookies;
using VersionOne.Components;

var builder = WebApplication.CreateBuilder(args); //toto vytvara novu web-aplikaciu tym ze vola builder metodu 

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//pridanie authentifikacie [login]

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(5);
        options.AccessDeniedPath = "/acces_denied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
