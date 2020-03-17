using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using repositoryMongoExample.Data;
using repositoryMongoExample.JWT;
using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using repositoryMongoExample.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.Extensions
{
    public static class ProjectExtensions
    {
        //this IServiceCollection services s'appelle une méthode d'extension
        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            var database = configuration.GetSection("MongoConnection:Database").Value;
            services.AddIdentityWithMongoStoresUsingCustomTypes<ApplicationUser, ApplicationRole>($"{connectionString}/{database}");
        }

        public static void ConfigureIOC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MyDbContext>();
            services.AddSingleton<TokenManager>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IService<IRepository<Employee>, Employee>, EmployeeService>();


        }

        public static void ConfigureDbSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbSettings>(Options =>
            {
                Options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
                Options.Database = configuration.GetSection("MongoConnection:Database").Value;
            });
        }

        public static void ConfigureJwtSettings(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JwtSettings>(Options =>
            {
                Options.SigningKey = configuration.GetSection("JwtSettings:SigningKey").Value;
                Options.Audience = configuration.GetSection("JwtSettings:Audience").Value;
                Options.Issuer = configuration.GetSection("JwtSettings:Issuer").Value;
                Options.LifeTime = configuration.GetSection("JwtSettings:LifeTime").Value;
            });
        }
    }
}
