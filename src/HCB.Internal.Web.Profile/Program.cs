using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HCB.Internal.Web.RCL;
using TG.Blazor.IndexedDB;
using HCB.Internal.Web.Data;

namespace HCB.Internal.Web.Profile
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            if (builder.HostEnvironment.Environment == "Development")
                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:9001") });
            else
                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Register Needed Scopes
            RegisterJsScopes(builder.Services);
            ConfigureInternalWebData(builder.Services);


            await builder.Build().RunAsync();
        }

        public static void ConfigureInternalWebData(IServiceCollection services)
        {
            var contextFactory = new ContextFactory();
            services.AddIndexedDB(dbStore =>
            {
                contextFactory.ConfigureDB(dbStore);
            });
            services.AddSingleton<ContextFactory>(contextFactory);
            services.AddScoped<Context>();
        }

        /// Register js interops that are needed
        public static void RegisterJsScopes(IServiceCollection services)
        {
            #region HCB.Internal.Web.RCL
            services.AddScoped<ExampleJsInterop>();
            #endregion
        }
    }
}
