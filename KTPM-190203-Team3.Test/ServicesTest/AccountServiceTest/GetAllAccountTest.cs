using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.AccountServiceTest
{
    [TestClass]
    public class GetAllAccountTest : BaseAccountTest
    {
        protected readonly DataContext _context;
        protected readonly AccountService _accountService;
        protected readonly List<Account> _accountMockData = AccountMockData.GetAccounts();

        public GetAllAccountTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            _accountService = new AccountService(_context);
            _context.Accounts.AddRange(AccountMockData.GetAccounts());
            _context.SaveChanges();
        }

        #region Compare between Service.GetAllAccount and MockData
        /// <summary>
        /// TestCase1 Compare between Service.GetAllAccount and MockData
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Case1()
        {
            /// Arrange
            InitData();

            /// Act
            var result = _accountService.GetAllAccount().Count;
            var expected = _accountMockData.Count;

            /// Assert
            Assert.AreEqual(result , expected);

        }
        #endregion

        /// <summary>
        /// TestCase2 Add new Account then compare Service.GetAllAccount and EntityAccountCount
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Case2()
        {
            InitData();
            /// Arrange
            var newAccount = AccountMockData.NewAccount();

            /// Act
             _accountService.RegisterAccount(newAccount);
            int result = _context.Accounts.Count();
            int expected = (_accountMockData.Count() + 1);

            /// Assert
            Assert.AreEqual(result, expected);

        }

        /// <summary>
        /// Test case failed
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Case3()
        {
            InitData();
            /// Arrange
            var newAccount = AccountMockData.NewAccount();

            /// Act
            await _accountService.RegisterAccount(newAccount);
            int result = _context.Accounts.Count();
                //int expected = (_accountMockData.Count() + 1);
            int expected = (_accountMockData.Count() );

            /// Assert
            Assert.AreEqual(result, expected);

        }

        /// <summary>
        /// Test count Account after update
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            InitData();
            /// Arrange
            accountService.UpdateAccount(new Account { Id = 1, CityId = 1, FirstName = "FirstNameUpdate", LastName = "LastName1", RoleId = 1, Email = "Email1@Email.com", MyProperty = 0, Password = "71e41a17623713bb12ee0b3c3b9cd96c" });

            /// Act
            var result = accountService.GetAllAccount().Count;
            var expected = _accountMockData.Count ;

            /// Assert
            Assert.AreEqual(result, expected);

        }

        /// <summary>
        /// Test count Account after delete
        /// </summary>
        [Fact]
        public async Task Case5()
        {
            InitData();
            /// Arrange
            var actual = accountService.GetAllAccount().Count;
            accountService.DeleteAccount(1);

            /// Act
            var result = accountService.GetAllAccount().Count;

            /// Assert
            Assert.AreEqual(result, actual - 1);

        }

    }
}
