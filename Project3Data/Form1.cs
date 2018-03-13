using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Other Methods
        private List<BicycleTheftModel> GetBicycleTheftsFromCSV()
        {
            List<BicycleTheftModel> bicycleTheftList = new List<BicycleTheftModel>();

            int lines = 0;
            int totalModelsCreated = 0;
            using (var reader = new StreamReader(@"FietsDiefstal.csv"))
            {
                while (!reader.EndOfStream)
                {
                    lines++;

                    var line = reader.ReadLine();

                    if (lines == 1)
                    {
                        continue;
                    }

                    var values = line.Split(',').ToList();
                    if (values.Count == 1)
                    {
                        continue;
                    }

                    string Kennisname = GetValue(values, 1);
                    string MKomschrijving = GetValue(values, 3);
                    string Werkgebied = GetValue(values, 6);
                    string Plaats = GetValue(values, 7);
                    string Buurt = GetValue(values, 8);
                    string Straat = GetValue(values, 9);
                    string Begindagsoort = GetValue(values, 10);
                    string Trefwoord = GetValue(values, 20);
                    string Object = GetValue(values, 21);
                    string merk = GetValue(values, 22);
                    string type = GetValue(values, 23);
                    string kleur = GetValue(values, 24);

                    DateTime parsedDate;
                    if (DateTime.TryParse(Kennisname, out parsedDate))
                    {
                        if (totalModelsCreated != 20197)//Is die laatste rare
                        {
                            bicycleTheftList.Add(new BicycleTheftModel() { ID = totalModelsCreated, Brand = merk, City = Plaats, Color = kleur, Date = parsedDate, DayOfTheWeek = Begindagsoort, Description = MKomschrijving, Keyword = Trefwoord, Location = Werkgebied, Neighbourhood = Buurt, Sort = Object, Street = Straat, Type = type });
                            totalModelsCreated++;
                        }
                    }
                }
            }

            return bicycleTheftList;
        }

        private List<WeatherModel> GetWeatherFromTextFile()
        {
            List<string> allLinesText = File.ReadAllLines(@"Weer2011-2013.txt").ToList();
            List<WeatherModel> filteredList = new List<WeatherModel>();



            int totalWeatherModelsCount = 0;
            foreach (var line in allLinesText)
            {
                if (line.Length > 0 && line.First() != '#')
                {
                    List<string> splittedLine = line.Split(',').ToList();

                    DateTime date = ConvertStringToDateTime(splittedLine[1]);
                    float dayAverageWindspeed = float.Parse(splittedLine[2], System.Globalization.NumberStyles.Number) * 0.1f;
                    float lowestHourAverageWindspeed = float.Parse(splittedLine[3], System.Globalization.NumberStyles.Number) * 0.1f;
                    int hourWindspeed = Convert.ToInt32(splittedLine[4]);
                    float dayAverageTemperature = float.Parse(splittedLine[5]) * 0.1f;
                    float minimumTemperature = float.Parse(splittedLine[6]) * 0.1f;
                    int hourMinimumTemperature = Convert.ToInt32(splittedLine[7]);
                    float maximumTemperature = float.Parse(splittedLine[8]) * 0.1f;
                    int hourMaximumTemperature = Convert.ToInt32(splittedLine[9]);
                    float rainfallDuration = float.Parse(splittedLine[10]) * 0.1f;
                    float rainfallDaySum = float.Parse(splittedLine[11]) * 0.1f;
                    float rainfallHighestHourSum = float.Parse(splittedLine[12]) * 0.1f;
                    int hourHighestRainfall = Convert.ToInt32(splittedLine[13]);

                    float parsedAverageDay = 0;
                    if (float.TryParse(splittedLine[14], out parsedAverageDay))
                    {
                        parsedAverageDay *= 0.1f;
                    }

                    WeatherModel newWeatherModel = new WeatherModel() { ID = totalWeatherModelsCount, AverageDayForecast = parsedAverageDay, Date = date, DayAverageTemperature = dayAverageTemperature, DayAverageWindspeed = dayAverageWindspeed, HourHighestRainfall = hourHighestRainfall, HourMaximumTemperature = hourMaximumTemperature, HourMinimumTemperature = hourMinimumTemperature, HourWindspeed = hourWindspeed, LowestHourAverageWindspeed = lowestHourAverageWindspeed, MaximumTemperature = maximumTemperature, MinimumTemperature = minimumTemperature, RainfallDaySum = rainfallDaySum, RainfallDuration = rainfallDuration, RainfallHighestHourSum = rainfallHighestHourSum };
                    filteredList.Add(newWeatherModel);
                    totalWeatherModelsCount++;
                }
            }

            return filteredList;
        }

        private DateTime ConvertStringToDateTime(string dateString)
        {
            string yearAsString = dateString[0] + "" + dateString[1] + "" + dateString[2] + "" + dateString[3];

            string month = dateString[4] + "" + dateString[5];
            string day = dateString[6] + "" + dateString[7];

            return DateTime.Parse(day + "/" + month + "/" + yearAsString);
        }

        string GetValue(List<string> list, int index)
        {
            if (list.Count > index)
            {
                return list[index];
            }

            return "";
        }
        #endregion
    }
}
