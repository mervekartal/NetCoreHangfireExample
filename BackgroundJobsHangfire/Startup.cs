using BackgroundJobsHangfire.Jobs;
using Data.Context;
using Data.Uow;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BackgroundJobsHangfire
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
            // hangfire
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration["ConnectionStrings:DefaultHangfireConnection"]));
            services.AddHangfireServer();

            var dbConfig = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProjectContext>(options => options
             .UseSqlServer("Server=DESKTOP-7DBKQJ6; Database=Odev2;Trusted_Connection=True;")
             );


            //Add AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // add uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectContext, ProjectContext>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackgroundJobsHangfire", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackgroundJobsHangfire v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //hangfire
            app.UseHangfireDashboard();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
