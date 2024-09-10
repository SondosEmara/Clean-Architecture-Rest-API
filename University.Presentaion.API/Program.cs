using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                builder.Services.AddInfrastructureDependencies(builder.Configuration);
                builder.Services.AddIdentity<AppUser, AppRole>(options => { }).AddEntityFrameworkStores<ApplicationyDbContext>().AddDefaultTokenProviders();
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


            app.MapControllers();

            app.Run();
        }
    }
}
