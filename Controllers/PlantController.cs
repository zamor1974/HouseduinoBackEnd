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
    [Route("plant")]
    public class PlantController : ControllerBase
    {
        private readonly ILogger<PlantController> _logger;


        public PlantController(ILogger<PlantController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Ritorna la lista di piante
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("all")]
        public ResponsePlant GetAll()
        {
            var response = new ResponsePlant();
            var db = new PlantDbHelper();
            response = db.GetAll().Result;

            return response;
        }

        /// <summary>
        /// Ritorna la lista di piante
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("humidity/all/{id_plant}")]
        public ResponsePlant GetAll(int idPianta)
        {
            var response = new ResponsePlant();
            var db = new PlantDbHelper();
            response = db.GetAllByPlant(idPianta).Result;

            return response;
        }

        /// <summary>
        /// Inserisce un'umidità di una pianta
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponsePlantInsert), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("humidity/insert")]
        public ResponsePlantInsert Insert(RequestPlant request)
        {
            var response = new ResponsePlantInsert();
            var db = new PlantDbHelper();
            response = db.Insert(request).Result;

            return response;
        }


        /// <summary>
        /// Ritorna l'ultima umidità registrata per la pianta
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("humidity/last/{id_plant}")]
        public ResponsePlant GetLast(int idPianta)
        {
            var response = new ResponsePlant();
            var db = new PlantDbHelper();
            response = db.GetLastByPlant(idPianta).Result;

            return response;
        }

        /// <summary>
        /// Ritorna le umidità registrate nell'ultima ora per la pianta
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObject), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("humidity/lasthour/{id_plant}")]
        public ResponsePlant GetLastHour(int idPianta)
        {
            var response = new ResponsePlant();
            var db = new PlantDbHelper();
            response = db.GetLastHourByPlant(idPianta).Result;

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
        [HttpGet("humidity/showdata/{id_plant}/{recordNumber}")]
        public ResponsePlant GetShowData(int idPianta,int recordNumber)
        {
            var response = new ResponsePlant();
            var db = new PlantDbHelper();
            response = db.GetShowDataByPlant(idPianta, recordNumber).Result;

            return response;
        }
    }

}

