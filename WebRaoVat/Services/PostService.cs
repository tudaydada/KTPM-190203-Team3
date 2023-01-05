using Microsoft.EntityFrameworkCore;
using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Services
{
    public interface IPostService
    {
        public List<Post> GetAllPost();
        public Post? GetPostById(int id);

        public Post? GetPostByIdActive(int id);
        public List<Post> GetPostByTitle(string title);
        public List<Post> GetAllPostActive();
        public List<Post> GetAllPostActive(int page);
        public bool IsExistPost(int postId);
        public void CreatePost(Post post);
        public bool UpdatePost(Post post);
        public bool DeletePost(int id);

    }
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;
        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreatePost(Post post)
        {
            _dataContext.Posts.Add(post);
            _dataContext.SaveChanges();
            return;
        }

        public bool DeletePost(int id)
        {
            var post = GetPostById(id);
            if (post == null) return false;
            _dataContext.Posts.Remove(post);
            _dataContext.SaveChanges();
            return true;
        }

        public List<Post> GetAllPost()
        {
            return _dataContext.Posts.Include(p => p.Category).Include(p => p.Account).OrderByDescending(p => p.EditedDate).ThenBy(p => p.CreatedDate).ToList();
        }

        public List<Post> GetAllPostActive()
        {
            return _dataContext.Posts.Include(p => p.Category).Include(p => p.Account).Where(p => p.Status == true && p.Category.Status == true).ToList();
        }
        const int PAGE_SIZE = 6;
        public List<Post> GetAllPostActive(int page = 1)
        {
            int skipN = (page - 1) * PAGE_SIZE;
            return _dataContext.Posts.Include(p => p.Category)
                .Where(p => p.Status == true && p.Category.Status == true)
                .OrderByDescending(p => p.EditedDate)
                .Skip(skipN).Take(PAGE_SIZE).ToList();
        }

        public Post? GetPostById(int id)
        {
            var post = _dataContext.Posts.Include(p => p.Category).Include(p => p.Comments).Include(p => p.Account).FirstOrDefault(p => p.Id == id);
            if (post != null) post.ViewCount += 1;
            _dataContext.Posts.Update(post);
            _dataContext.SaveChanges();
            return post;
        }

        public Post? GetPostByIdActive(int id)
        {
            var post = GetPostById(id);
            if (post.Status == false) return null;
            return post;
        }

        public List<Post> GetPostByTitle(string title)
        {
            return _dataContext.Posts.Where(_p => _p.Title.Contains(title)).ToList();
        }

        public bool IsExistPost(int postId)
        {
            return _dataContext.Posts.FirstOrDefault(p => p.Id == postId) != null;
        }

        public bool UpdatePost(Post post)
        {
            var current = GetPostById(post.Id);
            if (current == null) return false;
            if (string.IsNullOrEmpty(current.Title))
            {
                current.Title = post.Title;
            }
            if (string.IsNullOrEmpty(current.Description))
            {
                current.Description = post.Description;
            }   
            current.CategoryId = post.CategoryId;
            current.EditedDate = DateTime.Now;
            current.Status = post.Status;
            if (post.ImagePath != null)
            {
                current.ImagePath = post.ImagePath;
            }
            _dataContext.SaveChanges();
            return true;
        }
    }
}
