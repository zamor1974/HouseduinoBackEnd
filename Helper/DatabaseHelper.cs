using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HouseduinoBackEnd.Models;

namespace HouseduinoBackEnd.Helper
{
    public class DatabaseHelper{
        string connectionString;
        public DatabaseHelper(){
           connectionString=$"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable"; 
        }
    }
    public Activities GetActivities(){
        var activities = new Activities();

        return activities;
    }
}