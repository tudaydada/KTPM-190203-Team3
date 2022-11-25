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
    public class IsExistCategoryTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public IsExistCategoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(_context);
            _context.Categories.AddRange(CategoryMockData.GetCategories());
            _context.SaveChanges();
        }


        /// <summary>
        /// Test category is exist
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            /// Arrange
            var firstCategory = MockData.CategoryMockData.GetCategories().First();
            /// Act
            var result = categoryService.IsExistCategory(firstCategory);

            /// Assert
            Assert.IsTrue(result);
        }


        /// <summary>
        /// Test category is not exist
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange
            var newCategory = CategoryMockData.NewCategory();

            /// Act
            var result = categoryService.IsExistCategory(newCategory);

            ///Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test count Categories after delete
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            /// Arrange
            var firstCategory = categoryService.GetCategoryById(1);
            /// Act
            var result1 = categoryService.IsExistCategory(firstCategory);
            categoryService.DeleteCategory(1);
            var result2 = categoryService.IsExistCategory(firstCategory);

            /// Assert
            Assert.IsTrue(result1&&!result2);
        }

        /// <summary>
        /// Test category is exist after update
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            /// Arrange
            var firstCategory = categoryService.GetCategoryById(1);
            firstCategory.Id = 0;
            /// Act
            var result = categoryService.IsExistCategory(firstCategory);

            /// Assert
            Assert.IsTrue(result);
        }
        /// <summary>
        /// Test count Categories after create
        /// </summary>
        [Fact]
        public async Task Case5()
        {
            /// Arrange
            var count = categoryService.GetAllCategories().Count();
            /// Act
            var categoryNotExist = new Category { Id = count + 1 };
            var result1 = categoryService.IsExistCategory(categoryNotExist);
            var newCategory = MockData.CategoryMockData.NewCategory();
            categoryService.CreateCategory(newCategory);
            var result2 = categoryService.IsExistCategory(categoryNotExist);

            /// Assert
            Assert.IsTrue(!result1 && result2);
        }
    }
}
