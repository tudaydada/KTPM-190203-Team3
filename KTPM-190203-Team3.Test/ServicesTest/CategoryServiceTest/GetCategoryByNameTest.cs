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
    public class GetCategoryByNameTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public GetCategoryByNameTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(_context);
            _context.Categories.AddRange(CategoryMockData.GetCategories());
            _context.SaveChanges();
        }

        /// <summary>
        /// Test API get category by name with name is exist
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryByName("Category1");

            /// Assert
            Assert.IsNotNull(result);
        }


        /// <summary>
        /// Test API get category by name with name is not exist
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange
            var result = categoryService.GetCategoryByName("NotFound");

            /// Assert
            Assert.IsNull(result);
        }
        /// <summary>
        /// Test API get category by name after create new a category
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            /// Arrange
            /// Act
            categoryService.CreateCategory(MockData.CategoryMockData.NewCategory());
            var result = categoryService.GetCategoryByName("New");

            /// Assert
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// Test API get category by name after delete a category
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            /// Arrange
            /// Act
            categoryService.DeleteCategory(1);
            var result = categoryService.GetCategoryByName("1");

            /// Assert
            Assert.IsNull(result);
        }
        /// <summary>
        /// Test API get category by name after update a category
        /// </summary>
        [Fact]
        public async Task Case5()
        {
            /// Arrange
            /// Act
            categoryService.UpdateCategory(new Category { Id = 1, Name = "Update", Description = "update", Status = false });
            var result = categoryService.GetCategoryByName("1");

            /// Assert
            Assert.IsNull(result);
        }
        /// <summary>
        /// Test API get category by name with contain name
        /// </summary>
        [Fact]
        public async Task Case6()
        {
            /// Arrange
            /// Act
            var result = categoryService.GetCategoryByName("Category");
            /// Assert
            Assert.IsTrue(result.Count>1);
        }
    }
}
