using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Models;

namespace KTPM_190203_Team3.Test.MockData
{
    public class AccountMockData
    {
        public static List<Account> GetAccounts()
        {
            return new List<Account>() { 
                new Account{ Id = 1, CityId =1,FirstName = "FirstName1",LastName="LastName1",RoleId=1,Email = "Email1@Email.com",MyProperty=0,Password="71e41a17623713bb12ee0b3c3b9cd96c"},
                new Account{ Id = 2, CityId =2,FirstName = "FirstName2",LastName="LastName2",RoleId=2,Email = "Email2@Email.com",MyProperty=0,Password="71e41a17623713bb12ee0b3c3b9cd96c"},
                new Account{ Id = 3, CityId =3,FirstName = "FirstName3",LastName="LastName3",RoleId=3,Email = "Email3@Email.com",MyProperty=0,Password="71e41a17623713bb12ee0b3c3b9cd96c"},
                new Account{ Id = 4, CityId =4,FirstName = "FirstName4",LastName="LastName4",RoleId=4,Email = "Email4@Email.com",MyProperty=0,Password="71e41a17623713bb12ee0b3c3b9cd96c"},
                new Account{ Id = 5, CityId =5,FirstName = "FirstName5",LastName="LastName5",RoleId=5,Email = "Email5@Email.com",MyProperty=0,Password="71e41a17623713bb12ee0b3c3b9cd96c"},

            };
        }
        public static Account NewAccount()
        {
            return new Account { Id = 0, CityId = 1, FirstName = "NewFirstName", LastName = "NewLastName", RoleId = 1, Email = "NewEmail@Email.com", MyProperty = 0, Password = "71e41a17623713bb12ee0b3c3b9cd96c" };
                
        }
    }
}
