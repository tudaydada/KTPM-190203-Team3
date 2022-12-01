using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Models;

namespace KTPM_190203_Team3.Test.MockData
{
    public class RoleMockData
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>() { 
                new Role{Id = 1,Name = "Role1"},
                new Role{Id = 2,Name = "Role2"},
                new Role{Id = 3,Name = "Role3"},
                new Role{Id = 4,Name = "Role4"},
                new Role{Id = 5,Name = "Role5"},
            };
        }
        public Role NewRole() { return new Role {Id=0,Name="NewRole" }; }
    }
}
