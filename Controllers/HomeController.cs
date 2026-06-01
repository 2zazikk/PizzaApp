using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public HomeController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public async Task<IActionResult> Index()
        {
            var pizzas = await _pizzaService.GetAllPizzasAsync();
            return View(pizzas);
        }
    }
}