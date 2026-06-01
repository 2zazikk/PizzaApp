using PizzaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaApp.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly AppDbContext _context;

        public PizzaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pizza>> GetAllPizzasAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetPizzaByIdAsync(int id)
        {
            return await _context.Pizzas.FindAsync(id);
        }

        public async Task<Pizza> AddPizzaAsync(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<bool> DeletePizzaAsync(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return false;

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Pizza)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}