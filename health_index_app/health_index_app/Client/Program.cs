using health_index_app.Client;
using health_index_app.Client.Services;
using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Authentication;
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

builder.Services.AddSingleton(st => new HttpClient());
builder.Services.AddSingleton(st => new FatSecretClient(
        new FatSecretCredentials
        {
            ClientKey = "44a3ee4ca84b42ebb3234bc6bf66518c",
            ClientSecret = "29c8029e8f1b4fdcae11abc7d1babfdd"
        },
            new HttpClient()
    )
);
builder.Services.AddSingleton<IFatSecretAPIServices, FatSecretAPIServices>();


builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
