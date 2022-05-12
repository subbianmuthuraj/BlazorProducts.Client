using BlazorProducts.Client;
using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/api/") });
builder.Services.AddHttpClient("MuthurajApi", cl =>
    {
        cl.BaseAddress = new Uri("https://localhost:5001/api/");
    });
builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("MuthurajApi"));
builder.Services.AddScoped<ICountryHttpRepository, CountryHttpRepository>();

await builder.Build().RunAsync();
