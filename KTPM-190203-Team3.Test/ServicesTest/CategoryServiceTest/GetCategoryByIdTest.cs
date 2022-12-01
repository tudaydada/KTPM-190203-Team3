using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRaoVat.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    [TestClass]
    public class GetCategoryByIdTest : BaseCategoryTest
    {
        /// <summary>
        /// Test API get category by id with id is exist
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            InitData();
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
            InitData();
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
            InitData();
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
            InitData();
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
            InitData();
            /// Arrange
            /// Act
            categoryService.UpdateCategory(new Category { Id = 1, Name = "Update", Description = "update", Status = false });
            var result = categoryService.GetCategoryById(1);

            /// Assert
            Assert.IsNotNull(result);
        }
    }
}
