﻿using MediatR;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace University.Applicaation.Core.Dependencies
{
    public static class ModuleApplicationDependency
    {
        public static IServiceCollection AddApplicationCoreDependency(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }

    } 
}
