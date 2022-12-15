using System;
using System.Collections.Generic;

namespace HouseduinoBackEnd.Models
{
    public class RequestObject
    {
        public double valore { get; set; }
        public bool isValore { get; set; }
    }
    public class ResponseObject
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Object> data { get; set; }
    }

    public class ResponseObjectById
    {
        public int status { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
    }

    public class ResponseObjectIsActive
    {
        public int status { get; set; }
        public string message { get; set; }
        public bool active { get; set; }
    }

    public class ResponseObjectInsert
    {
        public int status { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
    }

    public class Object
    {

        /// <summary>
        /// Id dell'oggetto
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Valore dell'oggetto
        /// </summary>
        /// <example>10</example>
        public Double Valore { get; set; }

        /// <summary>
        /// Valore è booleano
        /// </summary>
        /// <example>false</example>
        public Boolean IsValore { get; set; }

        /// <summary>
        /// Data d'inserimento dell'oggetto
        /// </summary>
        /// <example>12/12/2000</example>
        public DateTime DateInsert { get; set; }
    }

    public class RequestObject2
    {
        public bool valore { get; set; }
    }
    public class ResponseObject2
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Object2> data { get; set; }
    }

    public class ResponseObject2ById
    {
        public int status { get; set; }
        public string message { get; set; }
        public Object2 data { get; set; }
    }

    public class ResponseObject2IsActive
    {
        public int status { get; set; }
        public string message { get; set; }
        public bool active { get; set; }
    }

    public class ResponseObject2Insert
    {
        public int status { get; set; }
        public string message { get; set; }
        public Object2 data { get; set; }
    }

    public class Object2
    {

        /// <summary>
        /// Id dell'oggetto
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Valore dell'oggetto
        /// </summary>
        /// <example>false</example>
        public Boolean Valore { get; set; }

        /// <summary>
        /// Data d'inserimento dell'oggetto
        /// </summary>
        /// <example>12/12/2000</example>
        public DateTime DateInsert { get; set; }
    }
}

