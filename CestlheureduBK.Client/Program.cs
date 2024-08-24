using Blazored.LocalStorage;
using CestlheureduBK.Client;
using CestlheureduBK.Common;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddRadzenComponents()
    .AddBlazoredLocalStorage()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddScoped<IDataService, FrontDataService>();

await builder.Build().RunAsync();
