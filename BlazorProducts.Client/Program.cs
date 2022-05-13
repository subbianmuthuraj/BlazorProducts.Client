
using Blazored.Toast;
using BlazorProducts.Client;
using BlazorProducts.Client.HttpInterceptor;
using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/api/") });
builder.Services.AddHttpClient("MuthurajApi", (sp, cl) =>
    {
        cl.BaseAddress = new Uri("https://localhost:5001/api/");
        cl.EnableIntercept(sp);
    });
builder.Services.AddBlazoredToast();
builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("MuthurajApi"));
builder.Services.AddHttpClientInterceptor();

builder.Services.AddScoped<ICountryHttpRepository, CountryHttpRepository>();

builder.Services.AddScoped<HttpInterceptorService>();

await builder.Build().RunAsync();
