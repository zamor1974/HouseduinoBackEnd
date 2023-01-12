using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HouseduinoBackEnd.Models;
using HouseduinoBackEnd.Helper;
using System.Reflection;
using Microsoft.AspNetCore.Cors;

namespace HouseduinoBackEnd.Controllers
{
    [ApiController]
    [EnableCors("SiteCorsPolicy")]
    [Route("activity")]
    public class ActvityController : ControllerBase
    {
        private readonly ILogger<ActvityController> _logger;


        public ActvityController(ILogger<ActvityController> logger)
        {
            _logger = logger;
        }

		/// <summary>
		/// Ritorna la lista di attività
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
			var db = new ActivityDbHelper();
            response = db.GetAll().Result;

			return response;
        }

        /// <summary>
        /// Ritorna le attività registrate nell'ultima ora
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
            var db = new ActivityDbHelper();
            response = db.GetLastHour().Result;

            return response;
        }

        /// <summary>
        /// Ritorna se il sensore è online o offline
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObjectIsActive), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("isactive")]
        public ResponseObjectIsActive GetIsActive()
        {
            var response = new ResponseObjectIsActive();
            var db = new ActivityDbHelper();
            response = db.GetIsActive().Result;

            return response;
        }


        /// <summary>
        /// Inserisce un'attività
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseObjectInsert), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("insert")]
        public ResponseObjectInsert Insert()
        {
            var response = new ResponseObjectInsert();
            var db = new ActivityDbHelper();
            response = db.Insert().Result;

            return response;
        }
    }
}