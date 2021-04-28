using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HCB.Internal.Web.Data;
using TG.Blazor.IndexedDB;

namespace HCB.Internal.Web.RCL.Gallery
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
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
    }
}
