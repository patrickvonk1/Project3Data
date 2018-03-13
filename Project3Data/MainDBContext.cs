using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3Data
{
    public class MainDBContext : DbContext
    {
        public MainDBContext() : base("Project3Database")
        {
        }

        public DbSet<BicycleTheftModel> BicycleThefts { get; set; }
        public DbSet<WeatherModel> WeatherModels { get; set; }
        public DbSet<ParkingGarageModel> ParkingGarageModel { get; set; }
    }
}
