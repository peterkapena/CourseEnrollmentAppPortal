using Blazored.LocalStorage;
using CourseEnrollmentApp_Portal;
using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpService(sp.GetRequiredService<IConfiguration>()));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<LoadingService>();

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
