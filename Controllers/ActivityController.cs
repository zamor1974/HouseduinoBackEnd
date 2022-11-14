using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HouseduinoBackEnd.Models;


/* / swagger:route GET /activity/all activity activityAll
// Get Activity list
//
// responses:
//  401: CommonError
//  200: GetActivities
func (h *BaseHandlerSqlx) GetActivitiesSqlx(w http.ResponseWriter, r *http.Request) {
	response := GetActivities{}

	activities := models.GetActivitiesSqlx(h.db.DB)

	response.Status = 1
	response.Message = lang.Get("success")
	response.Data = activities

	w.Header().Set("content-type", "application/json")
	json.NewEncoder(w).Encode(response)
}

// swagger:route GET /activity/isactive activity activityIsActive
// Get if sensor is online or offline
//
// responses:
//  401: CommonError
//  200: GetIsActive
func (h *BaseHandlerSqlx) GetIsActiveSqlx(w http.ResponseWriter, r *http.Request) {

	response := GetIsActive{}

	isActive := models.GetIsActiveSqlx(h.db.DB)

	response.Status = 1
	response.Active = isActive

	w.Header().Set("content-type", "application/json")
	json.NewEncoder(w).Encode(response)
}

// swagger:route GET /activity/lasthour activity activityLasthour
// Get list of last hour of Activity .... or the last value inserted
//
// responses:
//  401: CommonError
//  200: GetActivities
func (h *BaseHandlerSqlx) GetActivitiesLastHourSqlx(w http.ResponseWriter, r *http.Request) {
	response := GetActivities{}

	activities := models.GetActivitiesLastHourSqlx(h.db.DB)

	response.Status = 1
	response.Message = lang.Get("success")
	response.Data = activities

	w.Header().Set("content-type", "application/json")
	json.NewEncoder(w).Encode(response)
}

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
		[ProducesResponseType(typeof(Activities), 200)]
		[ProducesResponseType(typeof(IDictionary<string, string>), 400)]
		[ProducesResponseType(500)]
        [HttpGet("all")] 
        public Activities GetAll()
        {
            var activities = new Activities();
			activities.Elements=new List<Activity>();

			return activities;
        }
    }
}