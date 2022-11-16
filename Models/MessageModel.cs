using System;
using System.Collections.Generic;

namespace HouseduinoBackEnd.Models
{
    public class RequestMessage
    {
        public string messaggio { get; set; }
    }
    public class ResponseMessage
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Message> data { get; set; }
    }

    public class ResponseMessageById
    {
        public int status { get; set; }
        public string message { get; set; }
        public Message data { get; set; }
    }


    public class ResponseMessageInsert
    {
        public int status { get; set; }
        public string message { get; set; }
        public Message data { get; set; }
    }

    public class Message
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
        public string Messaggio { get; set; }

        /// <summary>
        /// Data d'inserimento dell'oggetto
        /// </summary>
        /// <example>12/12/2000</example>
        public DateTime DateInsert { get; set; }
    }

}

