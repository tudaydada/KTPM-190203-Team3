using System.Security.Cryptography;
using System.Text;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Models.Request;
using WebRaoVat.ViewModels;

namespace WebRaoVat.Services
{
    public interface IAccountService
    {
        List<Account> GetAllAccount();

        Task<Account> GetAccountById(int id);

        void UpdateAccount(Account account);

        Task<Account> RegisterAccount(Account account);

        Account LoginAccount(AccountRequest accountRequest);

        string GetMD5(string str);

        bool DeleteAccount(int id);

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

        public async Task<Account> RegisterAccount(Account account)
        {
            account.Password = GetMD5(account.Password);
            account.RoleId = 1;
            _context.Add(account);
            var result = await _context.SaveChangesAsync();

            return result > 0 ? account : null;
        }

        // create string MD5
        public string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public Account LoginAccount(AccountRequest accountRequest)
        {
            if(accountRequest == null)
            {
                return null;
            }
            var f_password = GetMD5(accountRequest.Password);
            var data = _context.Accounts.Where(s => s.Email.Equals(accountRequest.Email) && s.Password.Equals(f_password)).FirstOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
            
        }

        public void UpdateAccount(Account account)
        {
            var accUpdate = _context.Accounts.Where(e => e.Id == account.Id).FirstOrDefault();
            if (accUpdate != null)
            {
                accUpdate.Password = GetMD5(account.Password);
                accUpdate.RoleId = 1;
                accUpdate.Email = account.Email;
                accUpdate.LastName = account.LastName;
                accUpdate.FirstName = account.FirstName;

                _context.SaveChanges();
            }
        }

        public bool DeleteAccount(int id)
        {
            var account = GetAccountById(id);
            if(account == null)
            {
                return false;
            }
            else
            {
                _context.Remove(account);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
