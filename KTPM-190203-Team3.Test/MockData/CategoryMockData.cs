using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Models;

namespace KTPM_190203_Team3.Test.MockData
{
    public  class CategoryMockData
    {
        public static List<Category>  GetCategories() { 
            return new List<Category>() { 
            new Category{ Id = 1,Name="Category1",Description="Description1",Status=true},
            new Category{ Id = 2,Name="Category2",Description="Description2",Status=false},
            new Category{ Id = 3,Name="Category3",Description="Description3",Status=true},
            new Category{ Id = 4,Name="Category4",Description="Description4",Status=false},
            new Category{ Id = 5,Name="Category5",Description="Description5",Status=true},
        }; 
        }
        //public static Category GetCategory(int id) { };
        //public static Category GetCategory(string name) { };
        public static Category NewCategory()
        {
            return new Category { Id = 0, Name = "Category1", Description = "Description1", Status = true };
        }
    }
}
