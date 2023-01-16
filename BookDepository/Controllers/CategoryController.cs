using BookDepository.Models;
using BookDepository.DataAccess;
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
            if(categoryToInsert == null || !ModelState.IsValid)
                return View();

            _context.Categories.Add(categoryToInsert);
            _context.SaveChanges();
            TempData["success"] = "Category created succesfully";
            return RedirectToAction("Categories");
        }

        
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

           Category categoryToUpdate  = _context.Categories.Find(id);

            if (categoryToUpdate == null)
                return NotFound();



            return View(categoryToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category categoryToDelete)
        {
            if (categoryToDelete == null || !ModelState.IsValid)
                return View();

            _context.Categories.Update(categoryToDelete);
            _context.SaveChanges();
            TempData["success"] = "Category updated succesfully";

            return RedirectToAction("Categories");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category categoryToDelete = _context.Categories.Find(id);

            if (categoryToDelete == null)
                return NotFound();


            return View(categoryToDelete);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(Category categoryToDelete)
        {
            if (categoryToDelete == null || !ModelState.IsValid)
                return View();

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
            TempData["success"] = "Category deleted succesfully";

            return RedirectToAction("Categories");
        }
    }
}
