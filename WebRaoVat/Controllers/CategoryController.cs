using Microsoft.AspNetCore.Mvc;
using WebRaoVat.Models;
using WebRaoVat.Services;

namespace WebRaoVat.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewData["ListCategories"] = _categoryService.GetAllCategories();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Category"] = new Category();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null) return RedirectToAction("Index");
            ViewData["Category"] = category;
            return View();
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (_categoryService.UpdateCategory(category)) return RedirectToAction("Index");
            return Update(category.Id);
        }
        public IActionResult Delete(int categoryId)
        {
            if (_categoryService.DeleteCategory(categoryId)) return RedirectToAction("Index");
            return Update(categoryId);
        }
    }
}
