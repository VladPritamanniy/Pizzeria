using Microsoft.EntityFrameworkCore;
using Pizzeria.API.Infrastructure;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Mapper;
using Pizzeria.Application.Services;
using Pizzeria.Core.Repositories;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"),b => b.MigrationsAssembly("Pizzeria.Infrastructure")));

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
            builder.Services.AddAutoMapper(typeof(DtoProfile));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

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
