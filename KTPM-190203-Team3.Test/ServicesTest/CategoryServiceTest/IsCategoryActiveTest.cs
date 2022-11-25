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
    public class IsCategoryActiveTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public IsCategoryActiveTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(_context);
            _context.Categories.AddRange(CategoryMockData.GetCategories());
            _context.SaveChanges();
        }


        /// <summary>
        /// Test category is active with id
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            /// Arrange
            var categoryActiveFirst = categoryService.GetAllCategories().First(x=>x.Status==true);
            /// Act
            var result = categoryService.IsCategoryActive(categoryActiveFirst.Id);

            /// Assert
            Assert.IsTrue(result);
        }


        /// <summary>
        /// Test category is not active with id
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange
            var categoryInactiveFirst = categoryService.GetAllCategories().First(x => x.Status == false);
            /// Act
            var result = categoryService.IsCategoryActive(categoryInactiveFirst.Id);

            /// Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test category is active with id not exist
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            /// Arrange
            /// Act
            var result = categoryService.IsCategoryActive(0);

            /// Assert
            Assert.IsFalse(result);
        }

    }
}
