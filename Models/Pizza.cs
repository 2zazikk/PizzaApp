namespace PizzaApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}