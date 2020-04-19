using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using repositoryMongoExample.Data;
using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using repositoryMongoExample.services;

namespace repositoryMongoExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           
            // configure the database

            services.Configure<DbSettings>(Options =>
            {
                var User = Configuration.GetSection("MongoDB:User").Value;
                var Password = Configuration.GetSection("MongoDB:Password").Value;
                var Host = Configuration.GetSection("MongoDB:Host").Value;
                var Port = Configuration.GetSection("MongoDB:Port").Value;

                var Database = Configuration.GetSection("MongoDB:Database").Value;

                // var ConnString = $@"mongodb://{User}:{Password}@{Host}:{Port}";
                var ConnString = $@"mongodb://{Host}:{Port}";

                Options.ConnectionString = ConnString;
                Options.Database = Database;
                
            });

            services.AddSingleton<MyDbContext>();
            services.AddScoped<IRepository<Note>, NoteRepository>();
            services.AddScoped<IService<IRepository<Note>, Note>, NoteService>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IService<IRepository<Employee>, Employee>, EmployeeService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
