using Microsoft.AspNetCore.Mvc;
using WebRaoVat.Models;
using WebRaoVat.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebRaoVat.Controllers
{
    public class PostController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private IHostingEnvironment _hostingEnv;
        public PostController(ICategoryService categoryService, IPostService postService, ICommentService commentService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv)
        {
            _postService = postService;
            _categoryService = categoryService;
            _commentService = commentService;
            _hostingEnv = hostingEnv;

        }
        public IActionResult Index()
        {
            ViewData["ListPost"] = _postService.GetAllPost();
            return View();
        }

        public IActionResult Detail(int postId)
        {
            if (postId == 0) return View("Index");

            var post = _postService.GetPostByIdActive(postId);
            if (post == null) return NotFound();
            ViewData["Post"] = post;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Post"] = new Post();
            ViewData["Categories"] = _categoryService.GetAllCategoriesActive();
            ViewData["ListCategory"] = _categoryService.GetAllCategoriesActive();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Post post)
        {
            // post image file
            var postFiles = Request.Form.Files.Where(x => x.Name.ToLower().Equals("imagefile"));

            // handle post image
            if (postFiles.Count() > 0)
            {
                var folderUpload = "upload";
                foreach (var imageFile in postFiles)
                {
                    var formatFile = imageFile.FileName.Split('.').Last();
                    var fileName = Guid.NewGuid().ToString() + "." + formatFile;
                    var fileRelativePath = Path.Combine(_hostingEnv.WebRootPath, folderUpload, fileName);
                    using (var file = new FileStream(fileRelativePath, FileMode.Create))
                    {
                        imageFile.CopyTo(file);
                    }
                    post.ImagePath = String.Concat('/', folderUpload, '/', fileName);
                }
            }

            // handle main
            _postService.CreatePost(post);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["Post"] = post;
            }
            Console.WriteLine("Post: " + post.Title);
            ViewData["Categories"] = _categoryServices.GetAllCategoriesActive();
            ViewData["ListCategory"] = _categoryServices.GetAllCategoriesActive();
            return View();
        }
        [HttpPost]
        public IActionResult Update(Post post, IFormFile ImageFile)
        {
            var postFiles = Request.Form.Files.Where(x => x.Name.ToLower().Equals("imagefile"));
            if (postFiles.Count() > 0)
            {
                var folderUpload = "upload";
                foreach (var imageFile in postFiles)
                {
                    var formatFile = imageFile.FileName.Split('.').Last();
                    var fileName = Guid.NewGuid().ToString() + "." + formatFile;
                    var fileRelativePath = Path.Combine(_hostingEnv.WebRootPath, folderUpload, fileName);


                    using (var file = new FileStream(fileRelativePath, FileMode.Create))
                    {
                        //add file
                        imageFile.CopyTo(file);

                        //delete old file


                    }
                    post.ImagePath = String.Concat('/', folderUpload, '/', fileName);
                }
            }
            _postServices.UpdatePost(post);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int postId)
        {
            var post = _postServices.GetPostById(postId);
            if (post == null) return RedirectToAction("Create");

            _postServices.DeletePost(postId);
            return RedirectToAction("Index");

        }

        public void AddComment(Comment comment)
        {
            Console.WriteLine(string.IsNullOrEmpty(comment.Messages));
            if (string.IsNullOrEmpty(comment.Messages))
            {
                Index();
                return;
            }
            _commentServices.CreateComment(comment);
            Detail(comment.PostId);
            return;
        }
        public void ChangeStatus(int postId)
        {
            var post = _postServices.GetPostById(postId);
            if (post.Status == true) { post.Status = false; }
            else { post.Status = true; }
            _postServices.UpdatePost(post);
            return;
        }
    }
}
