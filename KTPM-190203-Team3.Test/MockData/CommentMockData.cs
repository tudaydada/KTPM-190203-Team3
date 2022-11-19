using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Models;

namespace KTPM_190203_Team3.Test.MockData
{
    public class CommentMockData
    {
        public static List<Comment> GetComments()
        {
            return new List<Comment>() { 
                new Comment{ Id = 1,AccountId= 1,PostId=1,Messages="Messages_Account1_Post1"},
                new Comment{ Id = 2,AccountId= 2,PostId=2,Messages="Messages_Account2_Post2"},
                new Comment{ Id = 3,AccountId= 3,PostId=3,Messages="Messages_Account3_Post3"},
                new Comment{ Id = 4,AccountId= 1,PostId=4,Messages="Messages_Account1_Post4"},
                new Comment{ Id = 5,AccountId= 2,PostId=5,Messages="Messages_Account2_Post5"},
                new Comment{ Id = 6,AccountId= 3,PostId=1,Messages="Messages_Account3_Post1"},
                new Comment{ Id = 7,AccountId= 1,PostId=2,Messages="Messages_Account1_Post2"},
                new Comment{ Id = 8,AccountId= 2,PostId=3,Messages="Messages_Account2_Post3"},
                new Comment{ Id = 9,AccountId= 3,PostId=4,Messages="Messages_Account3_Post4"},

            };
        }
        public Comment NewComment()
        {
            return new Comment { Id = 0, AccountId = 1, PostId = 1, Messages = "NewMessages_Account1_Post1" };
        }
    }
}
