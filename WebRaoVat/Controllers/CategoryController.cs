using Microsoft.AspNetCore.Mvc;
using WebRaoVat.Models;
using WebRaoVat.Services;

namespace WebRaoVat.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryServices;
        public CategoryController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public IActionResult Index()
        {
            ViewData["ListCategories"] = _categoryServices.GetAllCategories();
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
            _categoryServices.CreateCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int categoryId)
        {
            var category = _categoryServices.GetCategoryById(categoryId);
            if (category == null) return RedirectToAction("Index");
            ViewData["Category"] = category;
            return View();
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (_categoryServices.UpdateCategory(category)) return RedirectToAction("Index");
            return Update(category.Id);
        }
        public IActionResult Delete(int categoryId)
        {
            if (_categoryServices.DeleteCategory(categoryId)) return RedirectToAction("Index");
            return Update(categoryId);
        }
    }
}
