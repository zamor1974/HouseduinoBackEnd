using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseduinoBackEnd.Models;
using Npgsql;

namespace HouseduinoBackEnd.Helper
{
    public class DatabaseHelper
    {
        string connectionString;
        public DatabaseHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }

        private async Task<ResponseActivityById> GetActivityById(Int32 idValore)
        {
            var response = new ResponseActivityById();

            try
            {
                response.status = 1;
                response.message = "success";

                var query = string.Format(Queries.ACTIVITY_GET_BY_ID, idValore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Activity();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetInt32(1);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(2);

                    response.data= activity;
                }
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponseActivity> GetActivities()
        {
            var response = new ResponseActivity();

            response.data = new List<Activity>();
            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.ACTIVITY_GET);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Activity();
                     activity.Id = rdr.GetInt32(0);
                     activity.Valore = rdr.GetInt32(1);
                     activity.DateInsert = rdr.GetFieldValue<DateTime>(2);

                    response.data.Add(activity);
                }
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponseActivity> GetLastHour()
        {
            var response = new ResponseActivity();

            response.data = new List<Activity>();
            try
            {
                response.status = 1;
                response.message = "success";

                var dtFine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                var dtInizio = DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:ss");
                var query = string.Format(Queries.ACTIVITY_GET_LASTHOUR,dtFine,dtFine);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Activity();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetInt32(1);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(2);

                    response.data.Add(activity);
                }
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponseIsActive> GetIsActive()
        {
            var response = new ResponseIsActive();


            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.ACTIVITY_ISACTIVE);
                Int64 rdr = (Int64)await command.ExecuteScalarAsync();

                response.active = rdr > 0;
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.active = false;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponseInsert> Insert()
        {
            var response = new ResponseInsert();


            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.ACTIVITY_INSERT);
                Int32 rdr = (Int32)await command.ExecuteScalarAsync();
                var idValore = rdr;

                var responseById = GetActivityById(rdr);

                response.data = responseById.Result.data;

            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }
    }
}