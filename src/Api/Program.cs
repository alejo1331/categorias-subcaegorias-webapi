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
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Bussiness.Profiles;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//public IConfiguration Configuration { get; }

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AdministracionProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Categorias y SubCategorias", Version = "v1" });
});

AddDatabaseConfiguration(ref builder);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}    
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Categorias y Subcategorias V1");
    c.RoutePrefix = string.Empty;
});

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

bool IsDevelopmentEnvironment(string env) => env == "Development";

bool IsStagingEnvironment(string env) => env == "Staging";

bool IsProductionEnvironment(string env) => env == "Production";

void AddDatabaseConfiguration(ref WebApplicationBuilder builder)
{
    builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Context>(options =>
                options.UseSqlServer(("DefaultConnection")));

};



