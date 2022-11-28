using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class GetCategoryCountTest : BaseCategoryTest
    {
        /// <summary>
        /// Test count of mockdata and count of categoryService.GetAllCategories()  when init
        /// </summary>
        [Fact]
        public async Task Case1()
        {
            InitData();
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryCount(1);
            /// Assert
            Assert.IsTrue(result > 0);
        }


        /// <summary>
        /// Test count Categories after create
        /// </summary>
        [Fact]
        public async Task Case2()
        {
            InitData();
            /// Arrange

            /// Act
            var result = categoryService.GetCategoryCount(0);

            ///Assert
            Assert.IsTrue(result < 1);
        }
    }
}
