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

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    [TestClass]
    public class GetCategoryByIdTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public GetCategoryByIdTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(_context);
            _context.Categories.AddRange(CategoryMockData.GetCategories());
            _context.SaveChanges();
        }


        /// <summary>
        /// Test API get category by id with id is exist
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryById(1);

            /// Assert
            Assert.IsNotNull(result);
        }


        /// <summary>
        /// Test API get category by id with id is not exist
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange
            var result = categoryService.GetCategoryById(-1);

            /// Assert
            Assert.IsNull(result);
        }
        /// <summary>
        /// Test API get category by id after create new a category
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            /// Arrange
            /// Act
            categoryService.CreateCategory(MockData.CategoryMockData.NewCategory());
            var result = categoryService.GetCategoryById(6);

            /// Assert
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// Test API get category by id after delete a category
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            /// Arrange
            /// Act
            categoryService.DeleteCategory(1);
            var result = categoryService.GetCategoryById(1);

            /// Assert
            Assert.IsNull(result);
        }
        /// <summary>
        /// Test API get category by id after update a category
        /// </summary>
        [Fact]
        public async Task Case5()
        {
            /// Arrange
            /// Act
            categoryService.UpdateCategory(new Category { Id=1,Name="Update",Description="update",Status=false});
            var result = categoryService.GetCategoryById(1);

            /// Assert
            Assert.IsNotNull(result);
        }
    }
}
