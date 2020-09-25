using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ghost;

namespace BlazorGhost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });

            /// create regular scoped HttpClient
            builder.Services.AddScoped(client => new HttpClient {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            /// create singleton GhostService
            /// singleton needed for data caching to work
            builder.Services.AddSingleton<GhostService>(service => new CachedGhostService(
                new HttpClient {
                    BaseAddress = new Uri(GhostSettings.RestApiLocation)
            }));

            var host = builder.Build();
            var ghostService = host.Services.GetRequiredService<GhostService>();

            await host.RunAsync();
        }
    }
}
