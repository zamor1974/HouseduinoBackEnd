using System;
using HouseduinoBackEnd.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Object = HouseduinoBackEnd.Models.Object;

namespace HouseduinoBackEnd.Helper
{
    public class RainDbHelper
    {
        string connectionString;
        public RainDbHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }

        private async Task<ResponseObjectById> GetObjectById(Int32 idValore)
        {
            var response = new ResponseObjectById();

            try
            {
                response.status = 1;
                response.message = "success";

                var query = string.Format(Queries.RAIN_GET_BY_ID, idValore);

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
                await using var command = dataSource.CreateCommand(Queries.RAIN_GET);
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
                var query = string.Format(Queries.RAIN_GET_LAST_HOUR, dtInizio, dtFine);

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
                await using var command = dataSource.CreateCommand(Queries.RAIN_GET_LAST);
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
        public async Task<ResponseObjectInsert> Insert(RequestObject request)
        {
            var response = new ResponseObjectInsert();


            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.RAIN_POST_DATA, request.valore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                Int32 rdr = (Int32)await command.ExecuteScalarAsync();
                var idValore = rdr;

                var responseById = GetObjectById(rdr);

                response.data = responseById.Result.data;

            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponseObject> GetShowData(int recordNumber)
        {
            var response = new ResponseObject();

            response.data = new List<Object>();
            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.RAIN_GET_SHOWDATA, recordNumber);

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
    }

}

