using AutoMapper;
using Core;
using Core.MiddleWare;
using Data.Context;
using Data.Uow;
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

namespace Odev2_Bootcamp
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

            // add context 
            var dbConfig = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProjectContext>(options => options
             .UseSqlServer("Server=DESKTOP-7DBKQJ6; Database=Odev2;Trusted_Connection=True;")
             );

            // mapper
            //var mapperConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new MappingProfile());
            //});
            //services.AddSingleton(mapperConfig.CreateMapper());

            //Add AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // add uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectContext, ProjectContext>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Odev2_Bootcamp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Odev2_Bootcamp v1"));
            }

            // middleware
            app.UseMiddleware<RequestResponseMiddleWare>();
            app.UseMiddleware<RequestLoggingMiddleWare>();


        
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
