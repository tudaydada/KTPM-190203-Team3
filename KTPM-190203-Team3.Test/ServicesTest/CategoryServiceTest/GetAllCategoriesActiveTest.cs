﻿using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;
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
        [Fact]
        public async Task Case1()
        {
            /// Arrange

            /// Act
            var result = categoryService.GetAllCategories();

            /// Assert
            //result.Should().HaveCount(CategoryMockData.GetCategories().Count);
            Assert.AreEqual(result.Count, categoriesMockData.Count);
        }

        [Fact]
        public async Task Case2()
        {
            /// Arrange
            var newCategory = CategoryMockData.NewCategory();
            //_context.Categories.AddRange(CategoryMockData.GetCategories());
            //_context.SaveChanges();

            //var sut = new CategoryService(_context);

            /// Act
            categoryService.CreateCategory(newCategory);

            ///Assert
            int expectedRecordCount = (categoriesMockData.Count() + 1);
            Assert.AreEqual(_context.Categories.Count(), expectedRecordCount);
        }

        [Fact]
        public async Task Case3()
        {
            /// Arrange


            //var sut = new CategoryService(_context);

            /// Act
            var mockData = categoriesMockData.Where(x => x.Status == true).ToList();
            var result = categoryService.GetAllCategoriesActive();

            /// Assert
            //result.Should().HaveCount(CategoryMockData.GetCategories().Count);
            Assert.AreEqual(result.Count, mockData.Count);
        }

        [Fact]
        public async Task Case4()
        {
            /// Arrange


            //var sut = new CategoryService(_context);

            /// Act
            //var mockData = CategoryMockData.GetCategories().Where(x => x.Id == 1).FirstOrDefault();
            var result = categoryService.GetCategoryById(1);

            /// Assert
            //result.Should().HaveCount(CategoryMockData.GetCategories().Count);
            Assert.IsTrue(result != null && result.Id == 1);
        }
        [Fact]
        public async Task Case5()
        {
            /// Arrange
            //var sut = new CategoryService(_context);
            var name = "Category1";
            /// Act
            //var mockData = CategoryMockData.GetCategories().Where(x => x.Id == 1).FirstOrDefault();
            var result = categoryService.GetCategoryByName(name);

            /// Assert
            //result.Should().HaveCount(CategoryMockData.GetCategories().Count);
            Assert.IsTrue(result != null && result.Name.Equals(name));
        }

        [Fact]
        public async Task Case6()
        {
            /// Arrange
            //var sut = new CategoryService(_context);
            var categoryNotExist = CategoryMockData.NewCategory();
            var categoryExist = new Category { Id = 1, Name = "Category1", Description = "Description1", Status = true };
            /// Act
            //var mockData = CategoryMockData.GetCategories().Where(x => x.Id == 1).FirstOrDefault();
            var result1 = categoryService.IsExistCategory(categoryNotExist);
            var result2 = categoryService.IsExistCategory(categoryExist);

            /// Assert
            //result.Should().HaveCount(CategoryMockData.GetCategories().Count);
            Assert.IsTrue(result1 == false && result2 == true);
        }

        [Fact]
        public async Task Case7()
        {
            /// Arrange
            //var sut = new CategoryService(_context);
            var categoryNotExist = CategoryMockData.NewCategory();
            var categoryExist = new Category { Id = 1, Name = "Category1", Description = "Description1_updated", Status = false };
            /// Act
            //var mockData = CategoryMockData.GetCategories().Where(x => x.Id == 1).FirstOrDefault();
            var result1 = categoryService.UpdateCategory(categoryNotExist);
            var result2 = categoryService.UpdateCategory(categoryExist);

            /// Assert
            //result.Should().HaveCount(CategoryMockData.GetCategories().Count);
            Assert.IsTrue(result1 == false && result2 == true);
        }
    }
}