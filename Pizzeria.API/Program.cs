using Microsoft.EntityFrameworkCore;
using Pizzeria.API.Infrastructure;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Mapper;
using Pizzeria.Application.Services;
using Pizzeria.Core.Repositories;
using Pizzeria.Infrastructure.Data;
using FluentValidation;
using Pizzeria.Application.Validator;
using FluentValidation.AspNetCore;
using Pizzeria.Application.Factories;
using Pizzeria.Core.Options;

namespace Pizzeria.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"),b => b.MigrationsAssembly("Pizzeria.Infrastructure")));

            builder.Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<PizzaValidator>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("all", builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });


            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<ISizeService, SizeService>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IPizzaFactory, PizzaFactory>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            builder.Services.AddSingleton<ICloudinaryService, CloudinaryService>();
            builder.Services.AddAutoMapper(typeof(DtoProfile));
            builder.Services.Configure<CloudinaryOptions>(builder.Configuration.GetSection(nameof(CloudinaryOptions)));

            var app = builder.Build();
            await app.Services.MigrateDatabaseAsync();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler();

            app.UseAuthorization();
            app.UseCors("all");
            app.MapControllers();

            await app.RunAsync();
        }
    }
}
