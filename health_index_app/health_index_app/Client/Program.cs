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
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("health_index_app.ServerAPI"));

builder.Services.AddApiAuthorization();

builder.Services.AddScoped<IFatSecretAPIServices, FatSecretAPIServices>();
builder.Services.AddScoped<IMealFoodAPIServices, MealFoodAPIServices>();
builder.Services.AddScoped<IFoodAPIServices, FoodAPIServices>();
builder.Services.AddScoped<IMealsAPIServices, MealsAPIServices>();
builder.Services.AddScoped<IUserMealsAPIServices, UserMealsAPIServices>();

await builder.Build().RunAsync();