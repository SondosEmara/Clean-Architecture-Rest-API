using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Classes;
using University.Application.Layer.Services.Interfaces;

namespace University.Application.Layer.Dependency
{
    public static class ModuleApplicationDependency
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }

    } 
}
