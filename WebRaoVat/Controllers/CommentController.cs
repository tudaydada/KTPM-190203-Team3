using Microsoft.AspNetCore.Mvc;
using WebRaoVat.Services;

namespace WebRaoVat.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            ViewData["ListComments"] = _commentService.GetAllComments();
            return View();
        }
    }
}
