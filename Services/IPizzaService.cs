using PizzaApp.Models;

namespace PizzaApp.Services
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetAllPizzasAsync();
        Task<Pizza> GetPizzaByIdAsync(int id);
        Task<Pizza> AddPizzaAsync(Pizza pizza);
        Task<bool> DeletePizzaAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
    }
}