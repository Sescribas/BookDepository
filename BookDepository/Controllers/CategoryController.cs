using BookDepository.Models;
using BookDepository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookDepository.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _context;
        //private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Categories()
		{
			IEnumerable<Category> categories = _context.Categories;

			return View(categories);
		}


        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoryToInsert)
        {
            if(categoryToInsert == null)
                return View();

            _context.Categories.Add(categoryToInsert);
            _context.SaveChanges();

            return RedirectToAction("Categories");
        }
    }
}
