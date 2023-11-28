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
    [EnableCors]
    [Route("message")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;


        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Ritorna i messaggi registrati nell'ultima ora
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseMessage), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("lasthour")]
        public ResponseMessage GetLastHour()
        {
            var response = new ResponseMessage();
            var db = new MessageDbHelper();
            response = db.GetLastHour().Result;

            return response;
        }

        /// <summary>
        /// Inserisce un messsaggio
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseMessageInsert), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("insert")]
        public ResponseMessageInsert Insert(RequestMessage request)
        {
            var response = new ResponseMessageInsert();
            var db = new MessageDbHelper();
            response = db.Insert(request).Result;

            return response;
        }
    }

}

