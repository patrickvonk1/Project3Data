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

        public static List<BicycleTheftModel> GetBicycleTheftsByWeather(int minTemperature, int maxTemperature)
        {

            List<BicycleTheftModel> filteredBicycleThefts = new List<BicycleTheftModel>();
            List<WeatherModel> filteredWeatherModels = new List<WeatherModel>();

            using (MainDBContext context = new MainDBContext())
            {
                foreach (var weatherModel in context.WeatherModels)
                {
                    if (weatherModel.DayAverageTemperature >= minTemperature && weatherModel.DayAverageTemperature <= maxTemperature)  // date of weather when degrees is => input degrees 1 && <= input degrees 2 )
                    {
                        filteredWeatherModels.Add(weatherModel);
                    }
                }

                foreach (var theft in context.BicycleThefts)
                {
                    foreach (var weather in filteredWeatherModels)
                    {
                        if (theft.Date == weather.Date)
                        {
                            filteredBicycleThefts.Add(theft);
                            break;
                        }
                    }
                }
            }

            return filteredBicycleThefts;
        }
    }
}
// Maak een filter voor de fietsen die gestolen tussen 2 graden celsius bijvoorbeeld 100 fietsen tussen -5 en 5 graden