using CestlheureduBK;
using CestlheureduBK.Client.Components;
using CestlheureduBK.Common;
using CestlheureduBK.Components;
using CestlheureduBK.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<IDataService, BackDataService>()
    .AddLocalization()
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

app.MapPost("/api/offers", ([FromServices] IDataService dataService, [FromBody] OfferCriteria criteria) => dataService.GetOffers(criteria));
app.MapGet("/api/restaurant", ([FromServices] IDataService dataService) => dataService.GetRestaurant());
app.MapGet("/api/snacks", ([FromServices] IDataService dataService, string sortBy = "value", bool asc = false) => dataService.GetSnacks(sortBy, asc));
app.MapGet("/api/update", ([FromServices] IDataService dataService) => dataService.GetUpdate());

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Snacks).Assembly);

app.Run();
