using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Plantil.Data;
using System;

namespace Plantil.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ////migrate DB , in main using service scope
            //using (var scope = host.Services.CreateScope())
            //{
            //    try
            //    {
            //        var context = scope.ServiceProvider.GetService<PlantContext>();
            //        //delete DB & migrate on startup to clean slate
            //        context.Database.EnsureDeleted();
            //        context.Database.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex , "an error occured while migrating the DB");
            //        throw;
            //    }
            //}

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
