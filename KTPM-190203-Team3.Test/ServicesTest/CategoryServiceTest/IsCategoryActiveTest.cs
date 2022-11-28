using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class IsCategoryActiveTest : BaseCategoryTest
    {
        /// <summary>
        /// Test category is active with id
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            InitData();
            /// Arrange
            var categoryActiveFirst = categoryService.GetAllCategories().First(x => x.Status == true);
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
            InitData();
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
            InitData();
            /// Arrange
            /// Act
            var result = categoryService.IsCategoryActive(0);

            /// Assert
            Assert.IsFalse(result);
        }

    }
}
