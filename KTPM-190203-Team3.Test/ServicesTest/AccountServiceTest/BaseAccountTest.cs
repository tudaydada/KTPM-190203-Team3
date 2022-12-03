using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;

namespace KTPM_190203_Team3.Test.ServicesTest.AccountServiceTest
{
    public class BaseAccountTest
    {
        protected readonly DataContext _context;
        protected readonly AccountService accountService;
        protected readonly List<Account> accountMockData = AccountMockData.GetAccounts() ;
        public BaseAccountTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            accountService = new AccountService(_context);
        }
        public void InitData()
        {
            _context.RemoveRange(accountService.GetAllAccount());
            _context.Accounts.AddRange(AccountMockData.GetAccounts());
            _context.SaveChanges();
            return;
        }
    }
}
