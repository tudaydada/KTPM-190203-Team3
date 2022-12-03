using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Data;
using WebRaoVat.Services;
using WebRaoVat.Models;
using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;

namespace KTPM_190203_Team3.Test.ServicesTest.AccountServiceTest
{
    [TestClass]
    public class RegisterAccountTest : BaseAccountTest
    {
        protected readonly DataContext _context;
        protected readonly AccountService _accountService;
        protected readonly List<Account> _accountMockData = AccountMockData.GetAccounts();

        public RegisterAccountTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            _accountService = new AccountService(_context);
            _context.Accounts.AddRange(AccountMockData.GetAccounts());
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Case1()
        {
            InitData();
            /// Arrange
            

            /// Act
            

            /// Assert
            
        }

    }
}
