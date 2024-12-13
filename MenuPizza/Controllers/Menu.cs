using MenuPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuPizza.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;

        public Menu(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            //seleccionar platos de la entidad - select
            var dishes = from d in _context.Dishes
                       select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name!.ToUpper().Contains(searchString.ToUpper()));
                return View( await dishes.ToListAsync());
            }
            return View(await _context.Dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes.
                Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredient).
                FirstOrDefaultAsync(x => x.Id == id);
            if (dish == null) 
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
