using Microsoft.EntityFrameworkCore;
using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Services
{
    public interface ICommentServices
    {
        public List<Comment> GetAllComments();
        public Comment? GetCommentById(int id);
        public List<Comment> GetCommentByName(string name);
        public void CreateComment(Comment comment);
        public bool UpdateComment(Comment comment);
        public bool DeleteComment(int id);
    }
    public class CommentService : ICommentServices
    {
        private readonly DataContext _dataContext;
        public CommentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void CreateComment(Comment comment)
        {
            _dataContext.Comments.Add(comment);
            _dataContext.SaveChanges();
            return;
        }

        public bool DeleteComment(int id)
        {
            var comment = _dataContext.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null) return false;
            _dataContext.Comments.Remove(comment);
            _dataContext.SaveChanges();
            return true;
        }

        public List<Comment> GetAllComments()
        {
            return _dataContext.Comments.Include(co => co.Post).ToList();
        }

        public Comment? GetCommentById(int id)
        {
            return _dataContext.Comments.FirstOrDefault(co => co.Id == id);
        }

        public List<Comment> GetCommentByName(string name)
        {
            return _dataContext.Comments.Where(co => co.Messages.Contains(name)).ToList();
        }

        public bool UpdateComment(Comment comment)
        {
            var c = _dataContext.Comments.FirstOrDefault(co => co.Id == comment.Id);
            if (c == null) return false;
            _dataContext.Comments.Update(comment);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
