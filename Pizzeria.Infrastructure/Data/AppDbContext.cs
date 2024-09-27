using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Entities;

namespace Pizzeria.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() {}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<PizzaPrice> PizzaPrices { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
