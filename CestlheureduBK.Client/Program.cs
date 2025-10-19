using Majorsoft.Blazor.Extensions.BrowserStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder
    .Services.AddRadzenComponents()
    .AddBrowserStorage()
    .AddGeolocationServices()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
