using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Categorias.Domain.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Categorias.Domain.Bussiness.Profiles;
using Microsoft.OpenApi.Models;
using Categorias.Api.Utils;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment _env = builder.Environment;

if (_env.IsProduction())
    builder.Services.AddConsulConfig(configuration);

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

if (_env.IsDevelopment() || _env.IsStaging())
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Categorias y SubCategorias", Version = "v1" });
    });
}

AddDatabaseConfiguration(ref builder);

var app = builder.Build();

if (_env.IsDevelopment() || _env.IsStaging())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Categorias y SubCategorias - V1");
    });

    app.UseDeveloperExceptionPage();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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

app.Run();

//bool IsDevelopmentEnvironment(string env) => env == "Development";

//bool IsStagingEnvironment(string env) => env == "Staging";

//bool IsProductionEnvironment(string env) => env == "Production";

void AddDatabaseConfiguration(ref WebApplicationBuilder builder)
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));

};



