using CestlheureduBK;
using CestlheureduBK.Client.Components;
using CestlheureduBK.Components;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<DataService>()
    .AddLocalization()
    .AddGeolocationServices()
    .AddRadzenComponents()
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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

app.UseRequestLocalization("fr-FR");
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Snacks).Assembly);

app.Run();
