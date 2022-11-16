using System;
using System.Collections.Generic;

namespace HouseduinoBackEnd.Models
{
    public class RequestPlant
    {
        public int Id { get; set; }
        public double valore { get; set; }
    }
    public class ResponsePlant
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Plant> data { get; set; }
    }

    public class ResponsePlantById
    {
        public int status { get; set; }
        public string message { get; set; }
        public Plant data { get; set; }
    }

    public class ResponsePlantInsert
    {
        public int status { get; set; }
        public string message { get; set; }
        public Plant data { get; set; }
    }

    public class Plant
    {

        /// <summary>
        /// Id della pianta
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Nome della pianta
        /// </summary>
        /// <example>Geranio</example>
        public string Nome { get; set; }

        /// <summary>
        /// Valore dell'umidità della pianta
        /// </summary>
        /// <example>10</example>
        public Double Valore { get; set; }

        /// <summary>
        /// Data d'inserimento dell'umidità della pianta
        /// </summary>
        /// <example>12/12/2000</example>
        public DateTime DateInsert { get; set; }
    }

}

