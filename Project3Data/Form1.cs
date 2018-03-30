using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private List<ParkingGarageModel> GetParkingModelsFromTxtFiles()
        {

            var stringFilePaths = Directory.GetFiles("ParkingGarages");

            List<ParkingGarageModel> parkingModels = new List<ParkingGarageModel>();

            foreach (var filePath in stringFilePaths)
            {
                int BracketCount = 0;
                string ExampleJSON = new StreamReader(filePath).ReadToEnd();
                StringBuilder stringBuilder = new StringBuilder();

                foreach (char c in ExampleJSON)
                {
                    if (c == '{')
                        ++BracketCount;
                    else if (c == '}')
                        --BracketCount;
                    stringBuilder.Append(c);

                    if (BracketCount == 0 && c != ' ')
                    {
                        JObject jsonObj = JObject.Parse(stringBuilder.ToString());
                        Dictionary<string, string> jsonPropertyDic = jsonObj.ToObject<Dictionary<string, string>>();

                        DateTime dateTime = ConvertJSonDateTimeStringToDateTime(jsonPropertyDic["DateTime"]);
                        bool isOpen = bool.Parse(jsonPropertyDic["open"]);
                        string name = jsonPropertyDic["name"];
                        int parkingCapacity = int.Parse(jsonPropertyDic["parkingCapacity"]);
                        int vacantSpaces = int.Parse(jsonPropertyDic["vacantSpaces"]);

                        ParkingGarageModel newParkingModel = new ParkingGarageModel() { Date = dateTime, IsOpen = isOpen, Name = name, ParkingCapacity = parkingCapacity, VacantSpaces = vacantSpaces };

                        //ParkingGarageModel parsedJsonObject = JsonConvert.DeserializeObject<ParkingGarageModel>(stringBuilder.ToString());
                        parkingModels.Add(newParkingModel);

                        stringBuilder = new StringBuilder();
                    }
                }
            }

            return parkingModels;
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

        private DateTime ConvertJSonDateTimeStringToDateTime(string dateTime)//06-03-2018.16:00:01
        {
            string dayAsString = dateTime[0] + "" + dateTime[1];
            string monthAsString = dateTime[3] + "" + dateTime[4];
            string yearAsString = dateTime[6] + "" + dateTime[7] + "" + dateTime[8] + "" + dateTime[9];

            DateTime convertedDateTime = DateTime.Parse(dayAsString + "/" + monthAsString + "/" + yearAsString);

            string hours = dateTime[11] + "" + dateTime[12];
            string minuts = dateTime[14] + "" + dateTime[15];
            string seconds = dateTime[17] + "" + dateTime[18];
            TimeSpan d = new TimeSpan(int.Parse(hours), int.Parse(minuts), int.Parse(seconds));
            convertedDateTime = convertedDateTime.Add(d);
            return convertedDateTime;
        }

        private DateTime ConvertStringToDateTime(string dateString)
        {
            string yearAsString = dateString[0] + "" + dateString[1] + "" + dateString[2] + "" + dateString[3];

            string month = dateString[4] + "" + dateString[5];
            string day = dateString[6] + "" + dateString[7];
            System.Threading.Thread threadForCulture = new System.Threading.Thread(delegate () { });
            string format = threadForCulture.CurrentCulture.DateTimeFormat.ShortDatePattern;
            if(format == "M/d/yyyy")
            {
                return DateTime.Parse(month + "/" + day + "/" + yearAsString);
            }
            else
            {
                return DateTime.Parse(day + "/" + month + "/" + yearAsString);
            }
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

        private async void button1_Click(object sender, EventArgs e)
        {
            List<BicycleTheftModel> bicycleTheftModels = GetBicycleTheftsFromCSV();
            List<ParkingGarageModel> parkingModels = GetParkingModelsFromTxtFiles();
            List<WeatherModel> weatherModels = GetWeatherFromTextFile();

            using (MainDBContext dbContext = new MainDBContext())
            {
                //dbContext.BicycleThefts.AddRange(bicycleTheftModels);
                //dbContext.ParkingGarageModel.AddRange(parkingModels);
                //dbContext.WeatherModels.AddRange(weatherModels);

                await dbContext.SaveChangesAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Size = new Size(1227, 675);
            CreateButtonsParkingGarages();
        }

        private void BtnCreateSubgroup1Chart_Click(object sender, EventArgs e)
        {

        }

        private void CreateButtonsParkingGarages()
        {
            int i = 0;
            foreach (var garagaName in MainDBContext.GetAllParkingGarageName())
            {
                Panel newBtn = new Panel();
                newBtn.Width = 250;
                newBtn.Height = 35;
                newBtn.Visible = true;
                newBtn.BackgroundImage = panel1.BackgroundImage;
                newBtn.BackColor = Color.Transparent;
                newBtn.BackgroundImageLayout = ImageLayout.Zoom;
                Point p = new Point(0, 50 + i * 40);
                newBtn.Text = garagaName;
                newBtn.Location = p;
                //newBtn.Click += new EventHandler(button_Click);
             
                

                Label newLabel = new Label();
                newLabel.Text = garagaName;
                newLabel.Width = 230;
                newLabel.Location = new Point(20, 7);
                newLabel.ForeColor = Color.White;
                newLabel.BringToFront();
                newLabel.Click += new EventHandler(label_Click);
                newBtn.Controls.Add(newLabel);

                this.tabPage1.Controls.Add(newBtn);
                i++;
            }
        }

        //protected void button_Click(object sender, EventArgs e)
        //{
        //    var button = sender as Panel;
        //    Console.WriteLine(button.Text); // write button text (name of the parking garage)
           
        //    // Make new view!
        //}
        protected void label_Click(object sender, EventArgs e)
        {
            var button = sender as Label;
            foreach (var item in MainDBContext.GetAllDatesForParkingGarage(button.Text))
            {
                Console.WriteLine(item); // write all dates
            }
            //Console.WriteLine(button.Text); // write button text (name of the parking garage)

            // Make new view!
        }
    }
}
