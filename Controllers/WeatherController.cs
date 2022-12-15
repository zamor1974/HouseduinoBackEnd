using System;
using HouseduinoBackEnd.Helper;
using HouseduinoBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HouseduinoBackEnd.Controllers
{
    [ApiController]
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
    }

}

