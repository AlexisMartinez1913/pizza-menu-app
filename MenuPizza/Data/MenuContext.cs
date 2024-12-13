using Microsoft.EntityFrameworkCore;
using MenuPizza.Models;

namespace MenuPizza.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tabla intermedia con clave primaria compuesta
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            //relacion de uno a muchos entre dish y dish ingredient
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { 
                    Id = 1, 
                    Name = "Hawaina",
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.hogarmania.com%2Fcocina%2Frecetas%2Fpastas-pizzas%2Fpizza-hawaiana.html&psig=AOvVaw2bNE0-FfE2CycX3mL6T3nt&ust=1733863809036000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCrlJTIm4oDFQAAAAAdAAAAABAh",
                    price = 7.50,

                }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Queso Fundido"
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Piña"
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Jamón"
                }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 1
                },
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 2
                },
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 3
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
 
    }
}
