using System;
using HouseduinoBackEnd.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Object = HouseduinoBackEnd.Models.Object;
using System.IO;
using System.Reflection;

namespace HouseduinoBackEnd.Helper
{
	public class ActivityDbHelper
	{
        string connectionString;
        public ActivityDbHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }

        private async Task<ResponseObjectById> GetActivityById(Int64 idValore)
        {
            var response = new ResponseObjectById();

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
                    var activity = new Object();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetDouble(1);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(2);

                    response.data = activity;
                }
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponseObject> GetAll()
        {
            var response = new ResponseObject();

            response.data = new List<Object>();
            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.ACTIVITY_GET);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetDouble(1);
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

        public async Task<ResponseObject> GetLastHour()
        {
            var response = new ResponseObject();

            response.data = new List<Object>();
            try
            {
                response.status = 1;
                response.message = "success";

                var dtFine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                var dtInizio = DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:ss");
                var query = string.Format(Queries.ACTIVITY_GET_LASTHOUR, dtInizio, dtFine);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetDouble(1);
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

        public async Task<ResponseObject> GetLast()
        {
            var response = new ResponseObject();

            response.data = new List<Object>();
            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.ACTIVITY_GET_LAST);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetDouble(1);
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


        public async Task<ResponseObjectIsActive> GetIsActive()
        {
            var response = new ResponseObjectIsActive();


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

        public async Task<ResponseObjectInsert> Insert()
        {
            var response = new ResponseObjectInsert();


            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.ACTIVITY_INSERT);
                Int64 rdr = (Int64)await command.ExecuteScalarAsync();
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

