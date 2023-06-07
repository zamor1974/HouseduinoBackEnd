using System;
using HouseduinoBackEnd.Helper;
using HouseduinoBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace HouseduinoBackEnd.Controllers
{
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    [Route("temperature")]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;


        public TemperatureController(ILogger<TemperatureController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Ritorna la lista di temperature
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("all")]
        public ResponseObject GetAll()
        {
            var response = new ResponseObject();
            var db = new TemperatureDbHelper();
            response = db.GetAll().Result;

            return response;
        }

        /// <summary>
        /// Ritorna le temperature registrate nell'ultima ora
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("lasthour")]
        public ResponseObject GetLastHour()
        {
            var response = new ResponseObject();
            var db = new TemperatureDbHelper();
            response = db.GetLastHour().Result;

            return response;
        }

        /// <summary>
        /// Inserisce una temperatura
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObjectInsert), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("insert")]
        public ResponseObjectInsert Insert(RequestObject request)
        {
           var response = new ResponseObjectInsert();
            var db = new TemperatureDbHelper();
            response = db.Insert(request).Result;

            return response;
        }

        /// <summary>
        /// Ritorna la lista di n temperature
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("showdata/{recordNumber}")]
        public ResponseObject GetShowData(int recordNumber)
        {
            var response = new ResponseObject();
            var db = new TemperatureDbHelper();
            response = db.GetShowData(recordNumber).Result;

            return response;
        }
    }

}

