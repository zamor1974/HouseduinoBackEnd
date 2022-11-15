using System;
using System.Collections.Generic;

namespace HouseduinoBackEnd.Models{

    public class ResponseActivity
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Activity> data { get; set; }
    }

    public class ResponseActivityById
    {
        public int status { get; set; }
        public string message { get; set; }
        public Activity data { get; set; }
    }

    public class ResponseIsActive
    {
        public int status { get; set; }
        public string message { get; set; }
        public bool active { get; set; }
    }

    public class ResponseInsert
    {
        public int status { get; set; }
        public string message { get; set; }
        public Activity data { get; set; }
    }

    public class Activity{

        /// <summary>
        /// Id dell'attività
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Valore dell'attività
        /// </summary>
        /// <example>10</example>
        public int Valore { get; set; }

        /// <summary>
        /// Data d'inserimento dell'attività
        /// </summary>
        /// <example>12/12/2000</example>
        public DateTime DateInsert { get; set; }
    }

    public class ActivityModel{

    }
}