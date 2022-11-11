using Microsoft.EntityFrameworkCore;
using WebRaoVat.Models;
using WebRaoVat.Models.Request;

namespace WebRaoVat.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne<Category>(p => p.Category)
                .WithMany(ca => ca.Posts)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Comment>()
                .HasOne<Post>(co => co.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(co => co.PostId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

        }
    }
}
