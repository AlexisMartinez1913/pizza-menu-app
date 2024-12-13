namespace MenuPizza.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double price { get; set; }
        public List<DishIngredient>? DishIngredients { get; set; }
    }
}
