using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using PizzaApp.Services;
using System.Text.Json;

namespace PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public OrderController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public async Task<IActionResult> Cart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            var cartItems = new List<(Models.Pizza, int)>();

            if (!string.IsNullOrEmpty(cartJson))
            {
                var items = JsonSerializer.Deserialize<List<(int, int)>>(cartJson);
                foreach (var item in items)
                {
                    var pizza = await _pizzaService.GetPizzaByIdAsync(item.Item1);
                    if (pizza != null)
                        cartItems.Add((pizza, item.Item2));
                }
            }

            ViewBag.CartItems = cartItems;
            ViewBag.Total = cartItems.Sum(x => x.Item1.Price * x.Item2);
            return View();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
                return RedirectToAction("Index", "Home");

            var cartItems = JsonSerializer.Deserialize<List<(int, int)>>(cartJson);
            
            foreach (var item in cartItems)
            {
                var pizza = await _pizzaService.GetPizzaByIdAsync(item.Item1);
                order.Items.Add(new OrderItem
                {
                    PizzaId = pizza.Id,
                    Pizza = pizza,
                    Quantity = item.Item2,
                    Price = pizza.Price
                });
                order.TotalPrice += pizza.Price * item.Item2;
            }

            await _pizzaService.CreateOrderAsync(order);
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("OrderConfirmation", new { id = order.Id });
        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var order = await _pizzaService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return View(order);
        }
    }
}