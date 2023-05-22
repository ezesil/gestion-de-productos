using GestionDeProductos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GestionDeProductos
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddCors(options =>
                options.AddPolicy("PrimePolicy", x => x
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
            );

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Keycloak", options.ProviderOptions);
                // sample for code using
                //options.ProviderOptions.ResponseType = "code";
                //options.ProviderOptions.DefaultScopes.Add("address");
            });

            await builder.Build().RunAsync();
        }
    }
}