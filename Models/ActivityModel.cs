using System;
using System.Collections.Generic;

namespace HouseduinoBackEnd.Models{
    
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

    public class Activities{
        
        /// <summary>
        /// Lista delle attività
        /// </summary>
        public List<Activity> Elements { get; set; }
    }

    public class ActivityModel{

    }
}