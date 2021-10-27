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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Bussiness.Profiles;
using Microsoft.OpenApi.Models;
using Api.Utils;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment _env { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsProduction())
                services.AddConsulConfig(Configuration);

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(AdministracionProfile));
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
               builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            // Modo desarrollador y Pruebas
            if (_env.IsDevelopment() || _env.IsStaging())
            {
                // Register the Swagger generator, defining 1 or more Swagger documents
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Categorías y Subcategorías - API", Version = "v1" });
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Modo desarrollador y Pruebas
            if (_env.IsDevelopment() || _env.IsStaging())
            {
                // Habilita el middleware para servir Swagger generando un JSON.
                app.UseSwagger();

                // Habilita el middleware para servir el swagger-ui (html, js, css, etc.).
                // Especificación del Json Swagger.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Categorías y Subcategorías - V1");
                });

                app.UseDeveloperExceptionPage();

                //Permitir request desde cualquier Origen, cualquier Header, y cualquier Metodo (Get, Post, Put, Delete)
                app.UseCors(x =>
                   x.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());
            }
            
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            if (_env.IsProduction())
                app.UseConsul();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
