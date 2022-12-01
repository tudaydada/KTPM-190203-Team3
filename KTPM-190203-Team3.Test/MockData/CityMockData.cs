using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRaoVat.Models;

namespace KTPM_190203_Team3.Test.MockData
{
    public class CityMockData
    {
        public static List<City> GetCities()
        {
            return new List<City>() {
             new City{ Id = 1, Name = "City1" },
             new City{ Id = 2, Name = "City2" },
             new City{ Id = 3, Name = "City3" },
             new City{ Id = 4, Name = "City4" },
             new City{ Id = 5, Name = "City5" },
            };
        }
        public static City NewCity() {
            return new City {Id =0 ,  Name = "NewCity" };
            
            }
    }
}
