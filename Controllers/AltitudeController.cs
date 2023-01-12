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
    [Route("altitude")]
    public class AltitudeController : ControllerBase
    {
        private readonly ILogger<AltitudeController> _logger;


        public AltitudeController(ILogger<AltitudeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Ritorna la lista di altitudini
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
            var db = new AltitudeDbHelper();
            response = db.GetAll().Result;

            return response;
        }

        /// <summary>
        /// Ritorna le altitudini registrate nell'ultima ora
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
            var db = new AltitudeDbHelper();
            response = db.GetLastHour().Result;

            return response;
        }

        /// <summary>
        /// Inserisce un'altitudine
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
            var db = new AltitudeDbHelper();
            response = db.Insert(request).Result;

            return response;
        }

        /// <summary>
        /// Ritorna la lista di n altitudini
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
            var db = new AltitudeDbHelper();
            response = db.GetShowData(recordNumber).Result;

            return response;
        }
    }

}

