using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ZwiepsHaakHoek;
using ZwiepsHaakHoek.Extensions.ServiceCollection;
using ZwiepsHaakHoek.Services.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddServices(builder.Configuration, builder.HostEnvironment.BaseAddress);

var host = builder.Build();

var localization = host.Services.GetRequiredService<ILocalization>();
await localization.SetInitialCultureAsync();

await host.RunAsync();