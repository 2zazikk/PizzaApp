using Microsoft.AspNetCore.Mvc;
using PizzaApp.Data;
using PizzaApp.Models;
using PizzaApp.Services;
using Microsoft.EntityFrameworkCore;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly AppDbContext _context;

        public HomeController(IPizzaService pizzaService, AppDbContext context)
        {
            _pizzaService = pizzaService;
            _context = context;
        }

        public async Task<IActionResult> Index(string search, string sort)
        {
            var pizzas = await _pizzaService.GetAllPizzasAsync();

            // Поиск
            if (!string.IsNullOrEmpty(search))
            {
                pizzas = pizzas.Where(p => 
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // Сортировка
            pizzas = sort switch
            {
                "price_asc" => pizzas.OrderBy(p => decimal.Parse(p.Price.ToString())).ToList(),
                "price_desc" => pizzas.OrderByDescending(p => decimal.Parse(p.Price.ToString())).ToList(),
                "name" => pizzas.OrderBy(p => p.Name).ToList(),
                _ => pizzas
            };

            ViewBag.Search = search;
            ViewBag.Sort = sort;
            return View(pizzas);
        }
    }
}
