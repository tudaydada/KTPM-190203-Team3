using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;

namespace KTPM_190203_Team3.Test.ServicesTest.CategoryServiceTest
{
    public class BaseCategoryTest
    {
        protected readonly DataContext _context;
        protected readonly CategoryService categoryService;
        protected readonly List<Category> categoriesMockData = CategoryMockData.GetCategories();
        public BaseCategoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(_context);
        }
        public void InitData()
        {
            _context.RemoveRange(categoryService.GetAllCategories());
            _context.Categories.AddRange(CategoryMockData.GetCategories());
            _context.SaveChanges();
            return;
        }
    }
}
