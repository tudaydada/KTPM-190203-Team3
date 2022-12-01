using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Models;

namespace KTPM_190203_Team3.Test.MockData
{
    public class PostMockData
    {
        public static List<Post> GetPosts()
        {
            return new List<Post>() { 
             new Post{ Id = 1,Title="Title1",Description="Description1",AccountId =1,CategoryId=1,CityId=1,CreatedDate=new DateTime().AddDays(1),EditedDate=new DateTime().AddDays(1+2),ImagePath="",Status=true,ViewCount=11 },
             new Post{ Id = 2,Title="Title2",Description="Description2",AccountId =2,CategoryId=2,CityId=2,CreatedDate=new DateTime().AddDays(2),EditedDate=new DateTime().AddDays(2+2),ImagePath="",Status=false,ViewCount=12 },
             new Post{ Id = 3,Title="Title3",Description="Description3",AccountId =3,CategoryId=3,CityId=3,CreatedDate=new DateTime().AddDays(3),EditedDate=new DateTime().AddDays(3+2),ImagePath="",Status=true,ViewCount=13 },
             new Post{ Id = 4,Title="Title4",Description="Description4",AccountId =4,CategoryId=4,CityId=4,CreatedDate=new DateTime().AddDays(4),EditedDate=new DateTime().AddDays(4+2),ImagePath="",Status=false,ViewCount=14 },
             new Post{ Id = 5,Title="Title5",Description="Description5",AccountId =5,CategoryId=5,CityId=5,CreatedDate=new DateTime().AddDays(5),EditedDate=new DateTime().AddDays(5+2),ImagePath="",Status=true,ViewCount=15 },
            };
        }
        public Post NewPost() {
            return new Post { Id = 0, Title = "NewTitle", Description = "NewDescription", AccountId = 1, CategoryId = 1, CityId = 1, CreatedDate = new DateTime(), EditedDate = null, ImagePath = "", Status = false, ViewCount = 0 };
        }
    }
}
