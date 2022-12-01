using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;

namespace WebRaoVat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postServices;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryServices, IPostService postServices,DataContext context)
        {
            _logger = logger;
            this._categoryService = categoryServices;
            this._postServices = postServices;
            this._context = context;

        }

        public IActionResult Index(int page = 1)
        {
            ViewData["ListPost"] = _postServices.GetAllPostActive(page);
            ViewData["categories"] = _categoryService.GetAllCategories();
            return View();
        }

        [HttpGet]
        public IActionResult Search(Search search)
        {

            var ListPost = _postServices.GetAllPostActive();
            if (search.category != null)
                ListPost = ListPost.Where(p => p.Category.Name == search.category).ToList();
            else
                search.category = "All";
            if (search.keyword != null)
                ListPost = ListPost.Where(p => p.Title.Contains(search.keyword)).ToList();
            ViewData["categories"] = _categoryService.GetAllCategories();
            ViewData["ListPost"] = ListPost;
            ViewData["search"] = search;
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}