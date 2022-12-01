using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Repositories
{
    public interface ICommentRepository { }
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context)
        {
        }
    }
}
