using CestlheureduBK;
using CestlheureduBK.Client.Components;
using CestlheureduBK.Components;
using CestlheureduBK.Model;
using CestlheureduBK.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddScoped<GetDataService>()
    .AddScoped<UpdateDataService>()
    .AddScoped<UserService>()
    .AddLocalization()
    .AddGeolocationServices()
    .AddRadzenComponents()
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpContextAccessor().AddMicrosoftIdentityWebAppAuthentication(builder.Configuration);

builder.Services.Configure<CookieAuthenticationOptions>(
    CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.Cookie.MaxAge = TimeSpan.MaxValue;
    }
);

Directory.CreateDirectory("./data");
builder.Services.AddDbContext<BKDbContext>(e =>
    e.UseSqlite("Data Source=./data/bk.db").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);

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
fhOptions.KnownIPNetworks.Clear();
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

app.MapApiRoutes();

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<BKDbContext>().Database.MigrateAsync();
}

app.Run();
