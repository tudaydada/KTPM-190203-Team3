using KTPM_190203_Team3.Test.MockData;
using WebRaoVat.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class IsExistCategoryTest : BaseCategoryTest
    {
        /// <summary>
        /// Test category is exist
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            InitData();
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
            InitData();
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
            InitData();
            /// Arrange
            var firstCategory = categoryService.GetCategoryById(1);
            /// Act
            var result1 = categoryService.IsExistCategory(firstCategory);
            categoryService.DeleteCategory(1);
            var result2 = categoryService.IsExistCategory(firstCategory);

            /// Assert
            Assert.IsTrue(result1 && !result2);
        }

        /// <summary>
        /// Test category is exist after update
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            InitData();
            /// Arrange
            var firstCategory = _context.Categories.First();
            firstCategory.Id = 0;
            /// Act
            var result = categoryService.IsExistCategory(firstCategory);

            /// Assert
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Test count Categories after create
        /// </summary>
        [Fact]
        public async Task Case5()
        {
            InitData();
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
