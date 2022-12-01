using KTPM_190203_Team3.Test.MockData;
using WebRaoVat.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class GetAllCategoriesTest : BaseCategoryTest
    {
        /// <summary>
        /// Test count of mockdata and count of categoryService.GetAllCategories()  when init
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            /// Arrange
            InitData();
            /// Act
            var result = categoryService.GetAllCategories();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Count);
        }


        /// <summary>
        /// Test count Categories after create
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            /// Arrange
            InitData();
            var newCategory = CategoryMockData.NewCategory();

            /// Act
            categoryService.CreateCategory(newCategory);

            ///Assert
            int expectedRecordCount = (categoriesMockData.Count() + 1);
            Assert.AreEqual(_context.Categories.Count(), expectedRecordCount);
        }

        /// <summary>
        /// Test count Categories after update
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            InitData();
            /// Arrange
            categoryService.UpdateCategory(new Category { Id = 1, Name = "Category1 update", Description = "Description1 update", Status = true });

            /// Act
            var result = categoryService.GetAllCategories();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Count);
        }

        /// <summary>
        /// Test count Categories after delete
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            InitData();
            /// Arrange
            categoryService.DeleteCategory(1);

            /// Act
            var result = categoryService.GetAllCategories();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Count - 1);
        }
    }
}
