using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookBook_api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cookBook_api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Bara denna från början 
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<RecipeContext>();

            await LoadData.LoadRecipes(context);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
