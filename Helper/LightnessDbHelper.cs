using System;
using HouseduinoBackEnd.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Object = HouseduinoBackEnd.Models.Object;

namespace HouseduinoBackEnd.Helper
{
    public class LightnessDbHelper
    {
        string connectionString;
        public LightnessDbHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }

        private async Task<ResponseObject2ById> GetObjectById(Int64 idValore)
        {
            var response = new ResponseObject2ById();

            try
            {
                response.status = 1;
                response.message = "success";

                var query = string.Format(Queries.LIGHTNESS_GET_BY_ID, idValore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object2();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetBoolean(1);
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

        public async Task<ResponseObject2> GetAll()
        {
            var response = new ResponseObject2();

            response.data = new List<Object2>();
            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.LIGHTNESS_GET);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object2();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetBoolean(1);
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

        public async Task<ResponseObject2> GetLastHour()
        {
            var response = new ResponseObject2();

            response.data = new List<Object2>();
            try
            {
                response.status = 1;
                response.message = "success";

                var dtFine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                var dtInizio = DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:ss");
                var query = string.Format(Queries.LIGHTNESS_GET_LAST_HOUR, dtInizio, dtFine);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object2();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetBoolean(1);
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

        public async Task<ResponseObject2> GetLast()
        {
            var response = new ResponseObject2();

            response.data = new List<Object2>();
            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.LIGHTNESS_GET_LAST);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object2();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetBoolean(1);
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

        public async Task<ResponseObject2Insert> Insert(RequestObject2 request)
        {
            var response = new ResponseObject2Insert();


            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.LIGHTNESS_POST_DATA, request.valore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                Int64 rdr = (Int64)await command.ExecuteScalarAsync();
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

        public async Task<ResponseObject2> GetShowData(int recordNumber)
        {
            var response = new ResponseObject2();

            response.data = new List<Object2>();
            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.LIGHTNESS_GET_SHOWDATA, recordNumber);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Object2();
                    activity.Id = rdr.GetInt32(0);
                    activity.Valore = rdr.GetBoolean(1);
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

