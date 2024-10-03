using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ProyectoWeb.Client;
using ProyectoWeb.Client.Repositorios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:5115/") });
builder.Services.AddScoped<IRepositorioOC, RepositorioOC>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
