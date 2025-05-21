using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository context)
        {
            _categoryRepository = context;
        }

        // GET: Category/Add
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAllCategories;
            return View(categories);
        }
        public IActionResult Display(int id)
        {
            var categories = _categoryRepository.GetById(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        // POST: Category/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category category)
        {
                _categoryRepository.Add(category);
                return RedirectToAction("Index");
        

            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", category.Id);
            return View(categories);
        }

    }
}
