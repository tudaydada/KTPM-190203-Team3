using KTPM_190203_Team3.Test.MockData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Data;
using WebRaoVat.Models;
using WebRaoVat.Services;

namespace KTPM_190203_Team3.Test.ServicesTest.PostServiceTest
{
    public class BasePostTest
    {
        protected readonly DataContext _context;
        protected readonly PostService postService;
        protected readonly List<Post> postsMockData = PostMockData.GetPosts();
        public BasePostTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            postService = new PostService(_context);
        }
        public void InitData()
        {
            _context.RemoveRange(postService.GetAllPost());
            _context.Posts.AddRange(PostMockData.GetPosts());
            _context.SaveChanges();
            return;
        }
    }
}
