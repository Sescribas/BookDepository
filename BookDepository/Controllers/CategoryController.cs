using BookDepository.Data.Models;
using BookDepository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookDepository.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Categories()
		{
			IEnumerable<Category> categories = _context.Categories;

			return View(categories);
		}
	}
}
