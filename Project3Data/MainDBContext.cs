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

        public static List<BicycleTheftModel> GetBicycleTheftsByTemperature(int minTemperature, int maxTemperature)
        {

            List<BicycleTheftModel> filteredBicycleThefts = new List<BicycleTheftModel>();
            List<WeatherModel> filteredWeatherModels = new List<WeatherModel>();

            using (MainDBContext context = new MainDBContext())
            {
                foreach (var weatherModel in context.WeatherModels)
                {
                    if (weatherModel.DayAverageTemperature >= minTemperature && weatherModel.DayAverageTemperature <= maxTemperature)
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

        public static List<BicycleTheftModel> GetBicycleTheftsByWindSpeed(int minWindspeed, int maxWindspeed)
        {
            
            List<BicycleTheftModel> filteredBicycleThefts = new List<BicycleTheftModel>();
            List<WeatherModel> filteredWeatherModels = new List<WeatherModel>();

            using (MainDBContext context = new MainDBContext())
            {
                foreach (var weatherModel in context.WeatherModels)
                {
                    if (weatherModel.DayAverageWindspeed >= minWindspeed && weatherModel.DayAverageWindspeed <= maxWindspeed)
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

        public static List<BicycleTheftModel> GetBicycleTheftsByRainfall(int minRainfall, int maxRainfall)
        {

            List<BicycleTheftModel> filteredBicycleThefts = new List<BicycleTheftModel>();
            List<WeatherModel> filteredWeatherModels = new List<WeatherModel>();

            using (MainDBContext context = new MainDBContext())
            {
                foreach (var weatherModel in context.WeatherModels)
                {
                    if (weatherModel.RainfallDaySum >= minRainfall && weatherModel.RainfallDaySum <= maxRainfall)
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

        public static List<string> GetAllParkingGarageName()
        {
            List<string> allParkingGarageNames = new List<string>();

            using (MainDBContext context = new MainDBContext())
            {
                foreach (var parkingGaragaModel in context.ParkingGarageModel)
                {
                    if (!allParkingGarageNames.Contains(parkingGaragaModel.Name))
                    {
                        allParkingGarageNames.Add(parkingGaragaModel.Name);
                    }
                }
            }
            return allParkingGarageNames;

        }
        
        public static List<string> GetAllDatesForParkingGarage(string name)
        {
            List<string> allDates = new List<string>();

            using (MainDBContext context = new MainDBContext())
            {
                foreach (var info in context.ParkingGarageModel)
                {
                    if(info.Name == name)
                    {

                        // de data ziet er uit als 00/00/0000 00:00:00
                        // c# heeft een split functie je kan de string splitten op de " " [spatie]
                        // vervolgends kan je de contain functie op de index[0] van het split resultaat.
                        allDates.Add(info.Date.ToString());
                    }
                }
            }
            return allDates;
        }
    }
}
    
