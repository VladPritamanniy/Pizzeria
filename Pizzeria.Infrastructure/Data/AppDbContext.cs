using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Entities;

namespace Pizzeria.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() {}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPizza> OrderPizzas { get; set; }
        public DbSet<OrderPizzaAdditionalIngredient> OrderPizzaAdditionalIngredients { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<PizzaPrice> PizzaPrices { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaIngredient>()
                .Navigation(p => p.Ingredient)
                .AutoInclude();

            modelBuilder.Entity<PizzaPrice>()
                .Navigation(p => p.Size)
                .AutoInclude();

            modelBuilder.Entity<PizzaPrice>()
                .Navigation(p => p.Price)
                .AutoInclude();
        }
    }
}
