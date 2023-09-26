using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.DataLayer
{
    public static class TempDb
    {
        public static void PrePopulateData(IApplicationBuilder app)
        {
            using (var ServiceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(ServiceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext appDbContext)
        {
            if(!appDbContext.Platforms.Any())
            {
                Console.WriteLine("--- Seeding Data!");

                appDbContext.AddRange(
                    new Platform(){Name = ".NET", Publisher = "Microsoft", Cost="Free"},
                    new Platform(){Name = "JAVA", Publisher = "Google", Cost="OpenSource"},
                    new Platform(){Name = "ReactNative", Publisher = "Facebook", Cost="Licensed"}
                );

                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--- Data already Exists!!");
            }
        }
    }
}