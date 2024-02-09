using Blazored.LocalStorage;
using EmployeeManagementWeb;
using EmployeeManagementWeb.Common;
using EmployeeManagementWeb.Mapping;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ILocalStorage, LocalStorage>();
builder.Services.AddRefitClient<IEmployeeService>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https://localhost:7123/api");
});
builder.Services.AddRefitClient<IDepartmentService>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https://localhost:7123/api");
});
builder.Services.AddRefitClient<IUserService>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https://localhost:7123/api");
});
builder.Services.AddAutoMapper(typeof(EmployeeMapping));
builder.Services.AddTelerikBlazor();
await builder.Build().RunAsync();
