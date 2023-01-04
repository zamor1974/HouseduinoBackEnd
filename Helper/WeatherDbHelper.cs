using System;
using HouseduinoBackEnd.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Object = HouseduinoBackEnd.Models.Object;
using Microsoft.VisualBasic;

namespace HouseduinoBackEnd.Helper
{
    public class WeatherDbHelper
    {
        string connectionString;
        public WeatherDbHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }


        public Weather GetWeather()
        {
            var weather = new Weather();
            var dbTemperature = new TemperatureDbHelper();
            var dbPressure = new PressureDbHelper();
            var dbHumidity = new HumidityDbHelper();
            var dbActivity = new ActivityDbHelper();
            var dbLightness = new LightnessDbHelper();
            var dbAirQuality = new AirQualityDbHelper();

            var temperature = Math.Round(dbTemperature.GetLast().Result.data.ToArray()[0].Valore,2);

            var humidity = Math.Round(dbHumidity.GetLast().Result.data.ToArray()[0].Valore,2);

            var pressure = dbPressure.GetLast().Result.data.ToArray()[0].Valore;
            var lightness = dbLightness.GetLast().Result.data.ToArray()[0].Valore;
            var airQuality = dbAirQuality.GetLast().Result.data.ToArray()[0].Valore;
            var dateNow = DateTime.Now;
            var lastUpdate = dbActivity.GetLast().Result.data.ToArray()[0].DateInsert;
            //var prevision = GetPrevision(db)

            weather.Temperature = temperature;
            weather.Lightness = lightness;
            weather.Humidity = humidity;
            weather.AirQuality = airQuality;
            weather.Pressure = pressure;
            weather.ActualeDate = dateNow.ToString("dd/MM/yyyy HH:mm:ss");
            weather.DayOfTheWeek = ((int)dateNow.DayOfWeek);
            weather.LastUpdate = lastUpdate.ToString("dd/MM/yyyy HH:mm:ss");


            if (weather.Pressure > 1014)
            {
                weather.WeatherPrevision = Prevision.sunny;

                weather.WeatherDescription = "Sole";

            }
            if (weather.Pressure <= 1014 && weather.Pressure > 1008)
            {
                weather.WeatherPrevision = Prevision.cloudy;

                weather.WeatherDescription = "Variabile";

            }
            if (weather.Pressure <= 1008 && weather.Pressure > 1005)
            {
                weather.WeatherPrevision = Prevision.rain;

                weather.WeatherDescription = "Pioggia";

            }
            if (weather.Pressure <= 1005)
            {
                weather.WeatherPrevision = Prevision.storm_showers;

                weather.WeatherDescription = "Temporale";

            }

            return weather;
        }
    }

}

