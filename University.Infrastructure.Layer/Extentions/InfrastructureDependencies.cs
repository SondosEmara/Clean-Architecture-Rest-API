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
using University.Application.Layer.Helpers;
using University.Domain.Layer.Enities;
using University.Infrastructure.Layer.Context;
using University.Infrastructure.Layer.Repositories;
using University.Infrastructure.Layer.Seed;
using static System.Formats.Asn1.AsnWriter;

namespace University.Infrastructure.Layer.Extentions
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,IConfiguration configuration)
        {
              AddDbInfrastrucreConfig(services, configuration);
              AddInfrastructyreServicesRegistration(services);
             
              //configuration.GetSection(nameof(emailSettings)).;

            //   AddIdenity( services);
            return services;
        }

        //private static void AddIdenity()
        //{
        //     services.AddIdentity<AppUser, AppRole>(options => { }).AddEntityFrameworkStores<ApplicationyDbContext>().AddDefaultTokenProviders();

        //}

        public async static Task AddSeedDB(this IServiceProvider service)
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

        private static void AddInfrastructyreServicesRegistration(IServiceCollection services) 
        {
            services.AddScoped<Seeder, Seeder>();
            services.AddScoped<ICourseRepository, CourseRepositry>();
            services.AddScoped<IStudentRepositry, StudentRepositry>();
            services.AddScoped<IDepartmentRepository, DepartmentRepositry>();
        }
    }
}
