using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    [TestClass]
    public class GetAllCategoriesActiveTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public GetAllCategoriesActiveTest()
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
        public void Case1()
        {
            /// Arrange

            /// Act
            var result =  categoryService.GetAllCategoriesActive();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Where(x=>x.Status==true).ToList().Count);
        }


        /// <summary>
        /// Test count Categories after create
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange
            var newCategory = CategoryMockData.NewCategory();

            /// Act
            categoryService.CreateCategory(newCategory);

            ///Assert
            int expectedRecordCount = (categoriesMockData.Where(x=>x.Status==true).Count() + 1);
            Assert.AreEqual(_context.Categories.Count(), expectedRecordCount);
        }

        /// <summary>
        /// Test count Categories after update
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            /// Arrange
            categoryService.UpdateCategory(new Category { Id = 1, Name = "Category1 update", Description = "Description1 update", Status = false });

            /// Act
            var result = categoryService.GetAllCategoriesActive();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Count);
        }

        /// <summary>
        /// Test count Categories after delete
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            /// Arrange
            categoryService.DeleteCategory(1);

            /// Act
            var result = categoryService.GetAllCategories();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Count-1);
        }

    }
}
