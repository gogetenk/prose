using Auth0.AspNetCore.Authentication;
using Processia.Prose.WebApp.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Processia.Prose.WebApp.AuthenticationStateSyncer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.AddServiceDefaults();

builder.Services
    .AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

SetupAuthenticationEndpoints(app);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Processia.Prose.WebApp.Client._Imports).Assembly);

app.Run();

static void SetupAuthenticationEndpoints(WebApplication app)
{
    app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") =>
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(redirectUri)
                .Build();

        await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    });

    app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") =>
    {
        var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(redirectUri)
                .Build();

        await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    });
}
