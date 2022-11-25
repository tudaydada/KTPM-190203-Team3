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
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class GetCategoryCountTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public GetCategoryCountTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(_context);
            _context.Categories.AddRange(CategoryMockData.GetCategories());
            _context.SaveChanges();
        }


        /// <summary>
        /// Test count of mockdata and count of categoryService.GetAllCategories()  when init
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryCount(1);
            /// Assert
            Assert.IsTrue(result>0);
        }


        /// <summary>
        /// Test count Categories after create
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryCount(0);

            ///Assert
            Assert.IsTrue(result < 1);
        }
    }
}
