using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Repositories
{
    public interface IPostRepository { }
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DataContext context) : base(context)
        {
        }
    }
}
