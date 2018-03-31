using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

        public static List<BicycleTheftModel> GetBicycleTheftsByTemperature(float minTemperature, float maxTemperature)
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

        public static List<BicycleTheftModel> GetBicycleTheftsByWindSpeed(float minWindspeed, float maxWindspeed)
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

        public static List<BicycleTheftModel> GetBicycleTheftsByRainfall(float minRainfall, float maxRainfall)
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
            allParkingGarageNames.Add("All parking garages");
            return allParkingGarageNames;

        }

        public static List<string> GetAllDatesForParkingGarage(string name)
        {
            List<string> allDates = new List<string>();

            using (MainDBContext context = new MainDBContext())
            {
                var allParkingGarages = context.ParkingGarageModel;
                var parkingGaragesByDate = allParkingGarages.OrderBy(p => p.Date);

                foreach (var parkingGarage in parkingGaragesByDate)
                {
                    if (parkingGarage.Name == name || name == "All parking garages")
                    {
                        string[] newdate = parkingGarage.Date.ToString().Split(' ');
                        if (allDates.Contains(newdate[0]) == false)
                        {
                            allDates.Add(newdate[0]);
                        }
                        // de data ziet er uit als 00/00/0000 00:00:00
                        // c# heeft een split functie je kan de string splitten op de " " [spatie]
                        // vervolgends kan je de contain functie op de index[0] van het split resultaat.
                    }
                }
            }
            return allDates;
        }

        public static List<string> GetAlltimesForParkingGarage(string name, string date)
        {
            List<string> allTimes = new List<string>();

            using (MainDBContext context = new MainDBContext())
            {
                var allParkingGarages = context.ParkingGarageModel;
                var parkingGaragesByDate = allParkingGarages.OrderBy(p => p.Date);

                foreach (var parkingGarage in parkingGaragesByDate)
                {
                    if (parkingGarage.Name == name || name == "All parking garages")
                    {
                        string[] newdate = parkingGarage.Date.ToString().Split(' ');
                        string[] fixDate = newdate[1].Split(':');
                        if (allTimes.Contains(fixDate[0] + ":00") == false && newdate[0] == date)
                        {
                            allTimes.Add(fixDate[0] + ":00");
                        }
                    }
                }
            }
            return allTimes;
        }

        public static ParkingGarageModel GetGarageModel(string parkingName, string date, string time)
        {
            using (MainDBContext context = new MainDBContext())
            {
                var allParkingGarages = context.ParkingGarageModel;
                var parkingGaragesByDate = allParkingGarages.OrderBy(p => p.Date);

                foreach (var parkingModel in parkingGaragesByDate)
                {
                    if (parkingModel.Name == parkingName || parkingName == "All parking garages")
                    { //  && (parkingModel.Date == selectedDateTime)
                        var dateToCheck = parkingModel.Date.ToString().Split(' ');

                        if (dateToCheck[0].ToString() == date)
                        {
                            var checkDateTime = dateToCheck[1].Split(':');
                            string checkTime = (checkDateTime[0] + ":00");
                            if (time == checkTime)
                            {
                                return parkingModel;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public static String GetAvrTempDay(string date)
        {
            using (MainDBContext context = new MainDBContext())
            {
                foreach (var weatherModel in context.WeatherModels)
                {
                    var selectDate = weatherModel.Date.ToString().Split(' ');
                    if (selectDate[0] == date)
                    {
                        return weatherModel.DayAverageTemperature.ToString();
                    }
                }
                
            }
            return null;
        }
    }
}
