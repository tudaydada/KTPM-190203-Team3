using KTPM_190203_Team3.Test.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    [TestClass]
    public class GetAllCategoriesActiveTest : BaseCategoryTest
    {

        /// <summary>
        /// Test count of mockdata and count of categoryService.GetAllCategories()  when init
        /// </summary>
        [Fact]
        public void Case1()
        {
            /// Arrange
            InitData();
            /// Act
            var result = categoryService.GetAllCategoriesActive();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Where(x => x.Status == true).ToList().Count);
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
            int expectedRecordCount = (CategoryMockData.GetCategories().Where(x => x.Status == true).Count() + 1);
            int actualRecordCount = _context.Categories.Where(x => x.Status == true).Count();
            Assert.AreEqual(actualRecordCount, expectedRecordCount);
        }

        /// <summary>
        /// Test count Categories after update
        /// </summary>
        [Fact]
        public async Task Case3()
        {
            /// Arrange
            InitData();
            var actualResult = categoryService.GetAllCategoriesActive().Count;
            var firstCategoryActive = _context.Categories.Where(x => x.Status == true).First();
            firstCategoryActive.Status = false;

            categoryService.UpdateCategory(firstCategoryActive);

            /// Act
            var expectedResult = categoryService.GetAllCategoriesActive().Count;


            /// Assert
            Assert.AreEqual(actualResult - 1, expectedResult);
        }

        /// <summary>
        /// Test count Categories after delete
        /// </summary>
        [Fact]
        public async Task Case4()
        {
            /// Arrange
            InitData();
            categoryService.DeleteCategory(1);

            /// Act
            var result = categoryService.GetAllCategories();

            /// Assert
            Assert.AreEqual(result.Count, categoriesMockData.Count - 1);
        }

    }
} 
