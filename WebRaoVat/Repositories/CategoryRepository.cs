using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Repositories
{
    public interface ICategoryRepository
    {

    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
