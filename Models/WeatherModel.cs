using System;
namespace HouseduinoBackEnd.Models
{
	public class Prevision {
		public const string sunny = "wi-day-sunny";
		public const string rain_mix = "wi-day-rain-mix";
		public const string rain = "wi-rain";
		public const string storm_showers = "wi-storm-showers";
		public const string cloudy = "wi-cloudy";
		public const string snow = "wi-snow";
			}

	public class Weather
	{
		public double Temperature { get; set; }
		public double Humidity { get; set; }
		public double Pressure { get; set; }
		public string WeatherPrevision { get; set; }
		public string WeatherDescription { get; set; }
		public string LastUpdate { get; set; }
        public bool Lightness { get;  set; }
        public double AirQuality { get;  set; }
        public string ActualeDate { get;  set; }
        public int DayOfTheWeek { get;  set; }
    }
}