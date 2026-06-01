using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services;
using System.Text.Json;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var pizza = await _pizzaService.GetPizzaByIdAsync(id);
            if (pizza == null)
                return NotFound();

            return View(pizza);
        }

        public IActionResult AddToCart(int pizzaId, int quantity = 1)
        {
            var cart = HttpContext.Session.GetString("Cart");
            var items = string.IsNullOrEmpty(cart) 
                ? new List<(int, int)>() 
                : JsonSerializer.Deserialize<List<(int, int)>>(cart);

            var existingItem = items.FirstOrDefault(x => x.Item1 == pizzaId);
            if (existingItem != default)
            {
                items.Remove(existingItem);
                items.Add((pizzaId, existingItem.Item2 + quantity));
            }
            else
            {
                items.Add((pizzaId, quantity));
            }

            HttpContext.Session.SetString("Cart", 
                JsonSerializer.Serialize(items));

            return RedirectToAction("Index", "Home");
        }
    }
}