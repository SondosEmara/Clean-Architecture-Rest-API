using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Application.Layer.Dependency;
using University.Application.Layer.Helpers;
using University.Application.Layer.MiddleWare;
using University.Domain.Layer.Enities;
using University.Infrastructure.Layer.Context;
using University.Infrastructure.Layer.Extentions;
using University.Infrastructure.Layer.Seed;

namespace University.Presentaion.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            #region builderDependecny
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddInfrastructureDependencies(builder.Configuration)
                                .AddApplicationDependency()
                                .AddIdentity<AppUser, AppRole>(options => 
                                {
                                    options.SignIn.RequireConfirmedEmail = false;
                                    options.Password.RequireDigit = true;
                                    options.Lockout.MaxFailedAccessAttempts = 2;
                                    options.User.RequireUniqueEmail = true;
                                }).AddEntityFrameworkStores<ApplicationyDbContext>().AddDefaultTokenProviders();
            var emailSettings = new EmailSettings();

            builder.Configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);
            builder.Services.AddSingleton(emailSettings);

            #endregion


            #region App-Dependency
            var app = builder.Build();
            await app.Services.AddSeedDB();
            #endregion


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
