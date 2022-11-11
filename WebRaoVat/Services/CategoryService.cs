using Microsoft.EntityFrameworkCore;
using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.Services
{
    public class CategoryService
    {
        private readonly DataContext _dataContext;
        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void CreateCategory(Category category)
        {
            _dataContext.Add(category);
            _dataContext.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category == null) return false;
            _dataContext.Remove(category);
            _dataContext.SaveChanges();
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return _dataContext.Categories.Include(c => c.Posts).ToList();
        }

        public List<Category> GetAllCategoriesActive()
        {
            return GetAllCategories().Where(ca => ca.Status == true).ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _dataContext.Categories.FirstOrDefault(s => s.Id == id);
        }

        public Category? GetCategoryByName(string name)
        {
            return _dataContext.Categories.Include(p => p.Posts).FirstOrDefault(c => c.Name == name);
        }

        public int GetCategoryCount(int id)
        {
            return _dataContext.Categories.Count(c => c.Id == id);
        }

        public bool IsCategoryActive(int id)
        {
            return _dataContext.Categories.FirstOrDefault(c => c.Id == id && c.Status == true) != null;
        }

        public bool IsExistCategory(Category category)
        {
            return _dataContext.Categories.Contains(category);
        }

        public bool UpdateCategory(Category category)
        {
            var current = GetCategoryById(category.Id);
            if (current == null) return false;
            current.Name = category.Name;
            current.Description = category.Description;
            current.Status = category.Status;
            this._dataContext.SaveChanges();
            return true;
        }
    }
}
