using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ZwiepsHaakHoek;
using ZwiepsHaakHoek.Extensions.ServiceCollection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddServices(builder.Configuration, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();