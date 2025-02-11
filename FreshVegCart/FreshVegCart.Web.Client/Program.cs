using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FreshVegCart.Shared.Services;
using FreshVegCart.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the FreshVegCart.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
