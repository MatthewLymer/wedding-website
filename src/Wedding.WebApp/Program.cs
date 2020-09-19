using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Wedding.WebApp
{
    internal static class Program
    {
        private static Task Main(string[] args)
        {
            return CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var port = Environment.GetEnvironmentVariable("WW_PORT") ?? "5000";
            
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://*:{port}");
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
