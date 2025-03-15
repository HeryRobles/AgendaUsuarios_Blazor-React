using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AgendaUsuarios.Web;
using AgendaUsuarios.Web.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7196/")
});

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();



await builder.Build().RunAsync();
