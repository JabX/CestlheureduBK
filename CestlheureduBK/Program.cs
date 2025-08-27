using CestlheureduBK.Client.Components;
using CestlheureduBK.Components;
using CestlheureduBK.Model;
using CestlheureduBK.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<GetDataService>()
    .AddScoped<UpdateDataService>()
    .AddScoped<UserService>()
    .AddLocalization()
    .AddGeolocationServices()
    .AddRadzenComponents()
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services
    .AddHttpContextAccessor()
    .AddMicrosoftIdentityWebAppAuthentication(builder.Configuration);

Directory.CreateDirectory("./data");
builder.Services.AddDbContext<BKDbContext>(e => e
    .UseSqlite("Data Source=./data/bk.db")
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

var fhOptions = new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All };
fhOptions.KnownNetworks.Clear();
fhOptions.KnownProxies.Clear();
app.UseForwardedHeaders(fhOptions);

app.UseRequestLocalization("fr-FR");
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Snacks).Assembly);

app.MapPut("api/update/{codeRestaurant}", async (string codeRestaurant, [FromServices] UpdateDataService updateDataService) =>
{
    var (_, error) = await updateDataService.ReloadCatalogue(codeRestaurant);
    return error ? Results.BadRequest() : Results.Ok();
});

app.MapPut("api/favorite/{codeRestaurant}", async (string codeRestaurant, [FromServices] UserService userService) =>
{
    await userService.SetFavoriteRestaurant(codeRestaurant);
    return Results.Ok();
});

app.MapGet("/login", async context =>
{
    if (context.User.Identity?.IsAuthenticated != true)
    {
        await context.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }
    else
    {
        context.Response.Redirect("/");
    }
});

app.MapGet("/logout", async context =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await context.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new() { RedirectUri = "/" });
});

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<BKDbContext>().Database.MigrateAsync();
}

app.Run();
