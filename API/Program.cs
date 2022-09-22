using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance;

namespace API
{
    // we are going to create a variable var host, this means we store "CreateHostBuilder" command inside
    // our variable. Below that we write a using statement and we call it scope, what this does is that its 
    // going to create any services inside this method and it will store it inside scope.
    // inside try block we are going to get a hold of our data context.
    // var context is going to be a typo of our data context, we are geting
    // DataContext as a service because if we go back to our startup class
    // you can see that we added datacontext as a service.
    // we are going to populate Datacontext and store inside the context variable.
    // context.Database.Migrate(); => applies any pending migration for the 
    //context to the database and will create the database if it already doesnt exist.
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host1 = CreateHostBuilder(args).Build();

            using var scope = host1.Services.CreateScope();

            var services = scope.ServiceProvider;

            try{

                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();

                //this is where we call the method to seed the data
                // we say await because the seed method is going to return a task.
                // and we are going to parse the context as a parameter
                
                await Seed.SeedData(context);

            } catch (Exception ex)
            {
              var logger = services.GetRequiredService<ILogger<Program>>();
              logger.LogError(ex, "An error occured during migration");
            }
            await host1.RunAsync();
                //Logger is used for creating customized error log files//

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
