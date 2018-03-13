using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3Data
{
    public class WeatherModel
    {
        //ID For Database
        public int ID { get; set; }
        //datum
        public DateTime Date { get; set; }
        //etmaalgemiddelde windsnelheid
        public float DayAverageWindspeed { get; set; }
        //laagste uurgemiddelde windsnelheid
        public float LowestHourAverageWindspeed { get; set; }
        //uurvak waarin fhn is gemeten
        public int HourWindspeed { get; set; }
        //etmaalgemiddelde temperatuur
        public float DayAverageTemperature { get; set; }
        //minimum temperatuur
        public float MinimumTemperature { get; set; }
        //uurvak waarin tn is gemeten
        public int HourMinimumTemperature { get; set; }
        //maximum temperatuur
        public float MaximumTemperature { get; set; }
        //uurvak waarin tx is gemeten
        public int HourMaximumTemperature { get; set; }
        //duur van de neerslag
        public float RainfallDuration { get; set; }
        //etmaalsom van de neerslag
        public float RainfallDaySum { get; set; }
        //hoogste uursom van de neerslag
        public float RainfallHighestHourSum { get; set; }
        //uurvak waarin rhx is gemeten
        public int HourHighestRainfall { get; set; }
        //etmaalgemiddelde bewolking
        public float AverageDayForecast { get; set; }
    }
}
