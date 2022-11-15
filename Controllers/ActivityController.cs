using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HouseduinoBackEnd.Models;
using HouseduinoBackEnd.Helper;
using System.Reflection;


/* 


// swagger:route POST /activity/insert activity addActivity
// Create a new Activity value
//
// responses:
//  401: CommonError
//  200: GetActivity
func (h *BaseHandlerSqlx) PostActivitySqlx(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("content-type", "application/json")
	response := GetActivity{}

	decoder := json.NewDecoder(r.Body)
	var reqActivity *models.ReqAddActivity
	err := decoder.Decode(&reqActivity)
	//fmt.Println(err)

	if err != nil {
		json.NewEncoder(w).Encode(ErrHandler(lang.Get("invalid_request")))
		return
	}

	activity, errmessage := models.PostActivitySqlx(h.db.DB, reqActivity)
	if errmessage != "" {
		json.NewEncoder(w).Encode(ErrHandler(errmessage))
		return
	}

	response.Status = 1
	response.Message = lang.Get("insert_success")
	response.Data = activity
	json.NewEncoder(w).Encode(response)
} */


namespace HouseduinoBackEnd.Controllers
{
    [ApiController]
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
		[ProducesResponseType(typeof(ResponseActivity), 200)]
		[ProducesResponseType(typeof(IDictionary<string, string>), 400)]
		[ProducesResponseType(500)]
        [HttpGet("all")] 
        public ResponseActivity GetAll()
        {
            var response = new ResponseActivity();
			var db = new DatabaseHelper();
            response = db.GetActivities().Result;

			return response;
        }

        /// <summary>
        /// Ritorna le attività registrate nell'ultima ora
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseActivity), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("lasthour")]
        public ResponseActivity GetLastHour()
        {
            var response = new ResponseActivity();
            var db = new DatabaseHelper();
            response = db.GetLastHour().Result;

            return response;
        }

        /// <summary>
        /// Ritorna se il sensore è online o offline
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseIsActive), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet("isactive")]
        public ResponseIsActive GetIsActive()
        {
            var response = new ResponseIsActive();
            var db = new DatabaseHelper();
            response = db.GetIsActive().Result;

            return response;
        }


        /// <summary>
        /// Inserisce un'attività
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Operazione effettuata</response>
        /// <response code="400">Errore</response>
        [ProducesResponseType(typeof(ResponseInsert), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPost("insert")]
        public ResponseInsert Insert()
        {
            var response = new ResponseInsert();
            var db = new DatabaseHelper();
            response = db.Insert().Result;

            return response;
        }
    }
}