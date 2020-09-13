using System;
using System.Data.Entity;

namespace City.Models
{
    public class CityModel
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public DateTime VisitDate { get; set; }
        public string Country { get; set; }
        public decimal Fare { get; set; }
    }

    public class CityDBContext : DbContext
    {
        public DbSet<CityModel> cities { get; set; }
    }
}
