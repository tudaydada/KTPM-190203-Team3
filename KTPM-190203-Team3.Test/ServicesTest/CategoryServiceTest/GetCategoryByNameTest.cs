using WebRaoVat.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class GetCategoryByNameTest : BaseCategoryTest
    {

        /// <summary>
        /// Test API get category by name with name is exist
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            InitData();
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryByName("Category1");

            /// Assert
            Assert.IsTrue(result.Count > 0);
        }


        /// <summary>
        /// Test API get category by name with name is not exist
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            InitData();
            /// Arrange
            var result = categoryService.GetCategoryByName("NotFound");

            /// Assert
            Assert.IsTrue(result.Count == 0);
        }
        /// <summary>
        /// Test API get category by name after create new a category
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            InitData();
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
            InitData();
            /// Arrange
            /// Act
            categoryService.DeleteCategory(1);
            var result = categoryService.GetCategoryByName("1");

            /// Assert
            Assert.IsTrue(result.Count == 0);
        }
        /// <summary>
        /// Test API get category by name after update a category
        /// </summary>
        [Fact]
        public async Task Case5()
        {
            InitData();
            /// Arrange
            /// Act
            categoryService.UpdateCategory(new Category { Id = 1, Name = "Update", Description = "update", Status = false });
            var result = categoryService.GetCategoryByName("1");

            /// Assert
            Assert.IsTrue(result.Count == 0);
        }
        /// <summary>
        /// Test API get category by name with contain name
        /// </summary>
        [Fact]
        public async Task Case6()
        {
            InitData();
            /// Arrange
            /// Act
            var result = categoryService.GetCategoryByName("Category");
            /// Assert
            Assert.IsTrue(result.Count > 1);
        }
    }
}
