using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzeria.Infrastructure.Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Name", "BaseCost" },
                values: new object[,]
                {
                    { "Spinach", 2.50 },
                    { "Feta", 2.50 },
                    { "Mozzarella", 2.50 },
                    { "Chicken", 4.50 },
                    { "Ham", 4.50 },
                    { "Bacon", 4.50 },
                    { "Mushrooms", 2.50 },
                    { "Cheddar", 2.50 },
                    { "Sausages", 4.50 },
                    { "Salami", 4.50 },
                    { "Garlic sauce", 1.50 },
                    { "Onion", 2.50 },
                    { "Sun-dried tomatoes", 2.50 },
                    { "Alfredo sauce", 1.50 },
                    { "BBQ sauce", 1.50 },
                    { "Pepperoni", 4.50 },
                    { "Broccoli", 2.50 },
                    { "Cucumbers", 2.50 },
                    { "Pepper", 2.50 },
                    { "Olives", 2.50 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Name", "Diameter" },
                values: new object[,]
                {
                    { "Small", 20 },
                    { "Medium", 30 },
                    { "Large", 45 }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Pending" },
                    { "In Progress" },
                    { "Completed" },
                    { "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Name", "PublicImageId", "DisplayOrder" },
                values: new object[,]
                {
                    { "Margherita", "11EE7D6108E3A1C9952CD3A7F39A4D02_nibkii", 1 },
                    { "Pepperoni", "11EE7D6175C10773BFE36E56D48DF7E3_nf2nzt", 2 },
                    { "BBQ Chicken", "11EE7D6110059795842D40396BCF1E73_cmegsu", 3 },
                    { "Hawaiian", "6_p549uv", 4 },
                    { "Veggie Delight", "5_yt9zvc", 5 },
                    { "Meat Lovers", "7_dqfa1j", 6 },
                    { "Four Cheese", "4_qu1e3a", 7 },
                    { "Spicy Italian", "3_pq6l1c", 8 },
                    { "Buffalo Chicken", "1_qne4lk", 9 },
                    { "Mushroom Special", "2_b7itmg", 10 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Value" },
                values: new object[,]
                {
                    { 8.99m }, { 10.99m }, { 12.99m },
                    { 9.99m }, { 11.99m }, { 13.99m },
                    { 10.99m }, { 12.99m }, { 14.99m },
                    { 9.99m }, { 11.99m }, { 13.99m },
                    { 8.99m }, { 10.99m }, { 12.99m },
                    { 11.99m }, { 13.99m }, { 15.99m },
                    { 10.49m }, { 12.49m }, { 14.49m },
                    { 9.49m }, { 11.49m }, { 13.49m },
                    { 12.99m }, { 14.99m }, { 16.99m },
                    { 11.49m }, { 13.49m }, { 15.49m }
                });

            migrationBuilder.InsertData(
                table: "PizzaPrices",
                columns: new[] { "PizzaId", "SizeId", "PriceId" },
                values: new object[,]
                {
                    { 1, 1, 1 }, { 1, 2, 2 }, { 1, 3, 3 },
                    { 2, 1, 4 }, { 2, 2, 5 }, { 2, 3, 6 },
                    { 3, 1, 7 }, { 3, 2, 8 }, { 3, 3, 9 },
                    { 4, 1, 10 }, { 4, 2, 11 }, { 4, 3, 12 },
                    { 5, 1, 13 }, { 5, 2, 14 }, { 5, 3, 15 },
                    { 6, 1, 16 }, { 6, 2, 17 }, { 6, 3, 18 },
                    { 7, 1, 19 }, { 7, 2, 20 }, { 7, 3, 21 },
                    { 8, 1, 22 }, { 8, 2, 23 }, { 8, 3, 24 },
                    { 9, 1, 25 }, { 9, 2, 26 }, { 9, 3, 27 },
                    { 10, 1, 28 }, { 10, 2, 29 }, { 10, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "PizzaIngredients",
                columns: new[] { "PizzaId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 3 }, { 1, 11 }, { 1, 20 }, { 1, 8 },
                    { 2, 16 }, { 2, 10 }, { 2, 12 }, { 2, 7 }, { 2, 14 },
                    { 3, 4 }, { 3, 6 }, { 3, 19 }, { 3, 15 }, { 3, 13 },
                    { 4, 4 }, { 4, 5 }, { 4, 12 }, { 4, 9 }, { 4, 10 },
                    { 5, 3 }, { 5, 19 }, { 5, 8 }, { 5, 1 }, { 5, 13 },
                    { 6, 5 }, { 6, 16 }, { 6, 6 }, { 6, 4 }, { 6, 17 },
                    { 7, 3 }, { 7, 8 }, { 7, 10 }, { 7, 15 }, { 7, 14 },
                    { 8, 16 }, { 8, 10 }, { 8, 2 }, { 8, 7 }, { 8, 19 },
                    { 9, 4 }, { 9, 6 }, { 9, 15 }, { 9, 20 }, { 9, 18 },
                    { 10, 7 }, { 10, 8 }, { 10, 9 }, { 10, 1 }, { 10, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}