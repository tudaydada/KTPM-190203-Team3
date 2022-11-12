using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebRaoVat.Data;
using WebRaoVat.Models;

namespace WebRaoVat.UnitOfWork
{
    public interface IUnitOfWork
    {
        DbSet<Category> Categories { get; set; }

        void Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        public UnitOfWork()
        {
            context = new DataContext(new DbContextOptions<DataContext>());
            Categories= context.Categories;
        }
        public DbSet<Category> Categories { get ; set ; }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
