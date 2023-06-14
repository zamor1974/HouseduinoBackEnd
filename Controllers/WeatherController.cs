using System;
using HouseduinoBackEnd.Helper;
using HouseduinoBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using Object = HouseduinoBackEnd.Models.Object;

namespace HouseduinoBackEnd.Controllers
{
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;


        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Ritorna la previsione attuale
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(Weather), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("now")]
        public Weather GetAll()
        {
            var response = new Weather();
            var db = new WeatherDbHelper();
            response = db.GetWeather();

            return response;
        }

        /// <summary>
        /// I dati dalla dashboard
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(Dashboard), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("dashboard")]
        public Dashboard GetDashboard(bool addWeather)
        {
            var dashboard = new Dashboard();

            if (addWeather)
            {
                var weather = new Weather();
                var db = new WeatherDbHelper();
                weather = db.GetWeather();
                dashboard.Weather = weather;
            }
            var humidityHelper = new HumidityDbHelper();
            var humidity = humidityHelper.GetShowData(200).Result;

            var qualityHelper = new AirQualityDbHelper();
            var quality = qualityHelper.GetShowData(200).Result;

            var pressureHelper = new PressureDbHelper();
            var pressure = pressureHelper.GetShowData(200).Result;

            var rainHelper = new RainDbHelper();
            var rain = rainHelper.GetShowData(200).Result;

            var temperatureHelper = new TemperatureDbHelper();
            var temperature = temperatureHelper.GetShowData(200).Result;

            var airQualityHelper = new AirQualityDbHelper();
            var airQuality = airQualityHelper.GetShowData(200).Result;


            var orari = humidity.data.Select(t => new
            {
                dataPulita = new DateTime(t.DateInsert.Year, t.DateInsert.Month, t.DateInsert.Day, t.DateInsert.Hour, t.DateInsert.Minute, 0)

            }).Distinct().OrderBy(t=>t.dataPulita).ToList();

            foreach (var item in orari)
            {
                var hum =GetValue(humidity.data,item.dataPulita);
                var qual = GetValue(quality.data, item.dataPulita);
                var press = GetValue(pressure.data, item.dataPulita);
                var rai = GetValue(rain.data, item.dataPulita);
                var temp = GetValue(temperature.data, item.dataPulita);
                var air = GetValue(airQuality.data, item.dataPulita);

                dashboard.items.Add(new DashboardItem()
                {
                    AirQuality= air,
                    Humidity=hum,
                    Pressure=press,
                    Rain=rai,
                    Temperature=temp,
                    Date=item.dataPulita.ToString("HH:mm"),
                });
            }
            return dashboard;
        }

        private double GetValue(List<Object> elements,DateTime dataRef)
        {
            var valori = elements.Select(t => new
            {
                valore = t.Valore,
                dataPulita = new DateTime(t.DateInsert.Year, t.DateInsert.Month, t.DateInsert.Day, t.DateInsert.Hour, t.DateInsert.Minute, 0)

            }).ToList();

            var result = valori.Where(t => t.dataPulita == dataRef).ToList();
            if (result.Count() == 0)
                return 0;
            return result.Average(t => t.valore);
        }
    }

}

