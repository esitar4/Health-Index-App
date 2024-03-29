using Blazored.LocalStorage;
using health_index_app.Client;
using health_index_app.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("health_index_app.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("health_index_app.ServerAPI"))
    .AddBlazoredLocalStorage();

builder.Services.AddApiAuthorization();

builder.Services.AddScoped<IFatSecretAPIServices, FatSecretAPIServices>();
builder.Services.AddScoped<IMealFoodAPIServices, MealFoodAPIServices>();
builder.Services.AddScoped<IFoodAPIServices, FoodAPIServices>();
builder.Services.AddScoped<IMealAPIServices, MealAPIServices>();
builder.Services.AddScoped<IUserMealsAPIServices, UserMealsAPIServices>();
builder.Services.AddScoped<IAdminAPIServices, AdminAPIServices>();
builder.Services.AddScoped<IParentAPIServices, ParentAPIServices>();
builder.Services.AddScoped<ToastService>();

await builder.Build().RunAsync();
