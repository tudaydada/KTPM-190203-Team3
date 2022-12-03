using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace KTPM_190203_Team3.Test.ServicesTest.PostServiceTest
{
    public class GetAllPostTest : BasePostTest
    {
        [Fact]
        public void Case1()
        {
            /// Arrange
            InitData();
            /// Act
            var result = postService.GetAllPost().Count;
            //var result = _context.Posts.Count();
            var act = postsMockData.Count;

            /// Assert
            Assert.AreEqual(result, act);
        }
    }
}
