using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Email.Interfaces;

using University.Application.Layer.Services.Students.Classes;
using University.Application.Layer.Services.Students.Interface;

namespace University.Application.Layer.Dependency
{
    public static class ModuleApplicationDependency
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
           
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    } 
}
