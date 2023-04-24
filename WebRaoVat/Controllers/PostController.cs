using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebRaoVat.Controllers
{
    public class PostController : Controller
    {
        private readonly DataContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private IHostingEnvironment _hostingEnv;
        public PostController(DataContext context, ICategoryService categoryService, IPostService postService, ICommentService commentService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv)
        {
            _context = context;
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
            ViewData["Cities"] = _context.Cities.ToList();
            ViewData["ListCategory"] = _categoryService.GetAllCategoriesActive();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Post post)
        {
            var IdUser = HttpContext.Session.GetInt32("IdUser")??0;
            if (IdUser<1)
            {
                return RedirectToAction("Login", "Accounts", new { area = "" });
            }
            if(string.IsNullOrEmpty(post.Title) && string.IsNullOrEmpty(post.Description) && post.CategoryId<1)
            {
                return RedirectToAction("Create", "Post", new { area = "" });
            }
            var user = _context.Accounts.FirstOrDefault(x => x.Id == IdUser);
            if (user != null)
            {
                post.CityId = user.CityId;
            }
            else
            {
                var cityId = _context.Cities.FirstOrDefault().Id;
                post.CityId = cityId;
            }
            // post image file
            var postFiles = Request.Form.Files.Where(x => x.Name.ToLower().Equals("imagefile"));
            post.AccountId = IdUser;
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
            
            post.CreatedDate = DateTime.Now;
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
            ViewData["Categories"] = _categoryService.GetAllCategoriesActive();
            ViewData["ListCategory"] = _categoryService.GetAllCategoriesActive();
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
            _postService.UpdatePost(post);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null) return RedirectToAction("Create");

            _postService.DeletePost(postId);
            return RedirectToAction("Index");

        }

        public void AddComment(Comment comment)
        {
            if (string.IsNullOrEmpty(comment.Messages))
            {
                Index();
                return;
            }
            var idUser = HttpContext.Session.GetInt32("IdUser") ?? 0;
            comment.AccountId = idUser;
            _commentService.CreateComment(comment);
            Detail(comment.PostId);
            return;
        }
        public void ChangeStatus(int postId)
        {
            var post = _postService.GetPostById(postId);
            if (post.Status == true) { post.Status = false; }
            else { post.Status = true; }
            _postService.UpdatePost(post);
            return;
        }
    }
}
