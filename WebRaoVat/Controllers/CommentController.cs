using Microsoft.AspNetCore.Mvc;
using WebRaoVat.Services;

namespace WebRaoVat.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;
        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        public IActionResult Index()
        {
            ViewData["ListComments"] = _commentServices.GetAllComments();
            return View();
        }
    }
}
