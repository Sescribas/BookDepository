using BookDepository.Models;
using BookDepository.DataAccess;
using Microsoft.AspNetCore.Mvc;
using BookDepository.DataAccess.Repository.IRepository;
using BookDepository.DataAccess.Repository;

namespace BookDepository.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _uow;
        
        public CategoryController(IUnitOfWork uow)
		{
            _uow = uow;
		}

		public IActionResult Categories()
		{
			IEnumerable<Category> categories = _uow.Category.GetAll();

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

            _uow.Category.Create(categoryToInsert);
            _uow.Save();
            TempData["success"] = "Category created succesfully";
            return RedirectToAction("Categories");
        }

        
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

           Category categoryToUpdate = _uow.Category.Get(id.Value);


            if (categoryToUpdate == null)
                return NotFound();



            return View(categoryToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category categoryToUpdate)
        {
            if (categoryToUpdate == null || !ModelState.IsValid)
                return View();
            _uow.Category.Update(categoryToUpdate);
            _uow.Save();

            TempData["success"] = "Category updated succesfully";

            return RedirectToAction("Categories");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category categoryToDelete = _uow.Category.Get(id.Value);

            if (categoryToDelete == null)
                return NotFound();


            return View(categoryToDelete);
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category categoryToDelete)
        {
            if (categoryToDelete == null || !ModelState.IsValid)
                return View();

            _uow.Category.Delete(categoryToDelete);
            _uow.Save();
            TempData["success"] = "Category deleted succesfully";

            return RedirectToAction("Categories");
        }
    }
}
