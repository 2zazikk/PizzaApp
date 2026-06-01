using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

namespace PizzaApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Маргарита",
                    Description = "Классическая пицца с моцареллой и томатами",
                    Price = 499,
                    ImageUrl = "https://via.placeholder.com/300x200?text=Margherita",
                    Ingredients = new List<string> { "Тесто", "Томат", "Моцарелла", "Базилик" }
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Пепперони",
                    Description = "Пицца с острой колбасой пепперони",
                    Price = 549,
                    ImageUrl = "https://via.placeholder.com/300x200?text=Pepperoni",
                    Ingredients = new List<string> { "Тесто", "Томат", "Моцарелла", "Пепперони" }
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Четыре сыра",
                    Description = "Микс из четырех видов сыра",
                    Price = 599,
                    ImageUrl = "https://via.placeholder.com/300x200?text=FourCheese",
                    Ingredients = new List<string> { "Тесто", "Моцарелла", "Горгонзола", "Пармезан", "Фета" }
                },
                new Pizza
                {
                    Id = 4,
                    Name = "Ветчина и ананас",
                    Description = "Экзотическая пицца с ветчиной и ананасом",
                    Price = 549,
                    ImageUrl = "https://via.placeholder.com/300x200?text=Hawaii",
                    Ingredients = new List<string> { "Тесто", "Томат", "Моцарелла", "Ветчина", "Ананас" }
                }
            );
        }
    }
}
