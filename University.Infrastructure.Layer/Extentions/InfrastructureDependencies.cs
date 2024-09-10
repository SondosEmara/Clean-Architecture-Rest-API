using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Interfaces;
using University.Domain.Layer.Enities;
using University.Infrastructure.Layer.Context;
using University.Infrastructure.Layer.Seed;
using static System.Formats.Asn1.AsnWriter;

namespace University.Infrastructure.Layer.Extentions
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            #region DB-Infrastructure
              AddDbInfrastrucreConfig(services, configuration);
            #endregion
            /*  services
               .AddIdentityCore<AppUser>(opt =>
               {
                   // here you can add options for pass like (length, should have numbers), mail and others
                   opt.Password.RequireNonAlphanumeric = false;
               })
               .AddRoles<AppRole>()
               .AddRoleManager<RoleManager<AppRole>>()
               .AddSignInManager<SignInManager<AppUser>>()
               .AddEntityFrameworkStores<ElearningContext>();*/
            //#region Regitser
            //services.AddScoped<Seeder, Seeder>();
            //services.AddScoped<IDepartmentRepository, IDepartmentRepository>();
            //services.AddScoped<IStudentRepositry,StudentRepositry>();
            //services.AddScoped<, UserRepository>();
            //#endregion
            return services;
        }

        public async static Task AddInfrastructureSeedDB(this IServiceProvider service)
        {
            try
            {
                using (var scope = service.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
                    // ensures that you retrieve a valid instance of the seeder service registered in the DI container.
                    await seeder.RoleSeed();
                    await seeder.StudentSeed();
                }
            }
            catch (Exception) { }
        }


        private static void AddDbInfrastrucreConfig(IServiceCollection services,IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<ApplicationyDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
                });
            }
            catch(Exception) { }
          
        }
    }
}
