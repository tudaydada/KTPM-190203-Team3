using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Repositories
{
    public interface IAccountRepository { }

    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context)
        {
        }
    }
}
