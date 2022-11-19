using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Services
{
    public interface IAccountService
    {
        List<Account> GetAllAccount();

        Task<Account> GetAccountById(int id);

        void Update(Account account);

    }

    public class AccountService : IAccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountById(int id)
        {
            return _context.Accounts.Where(acc => acc.Id == id).FirstOrDefault();
        }

        public List<Account> GetAllAccount()
        {
            return _context.Accounts.ToList();
        }

        public void Update(Account account)
        {
            var accUpdate = _context.Accounts.Where(acc => acc.Id == account.Id).FirstOrDefault();
            if (accUpdate != null)
            {
                accUpdate.Email = account.Email;
                accUpdate.LastName = account.LastName;
                accUpdate.FirstName = account.FirstName;
                accUpdate.RoleId = account.RoleId;

                _context.SaveChanges();
            }
        }
    }
}
