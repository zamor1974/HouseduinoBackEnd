using System;
using HouseduinoBackEnd.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Object = HouseduinoBackEnd.Models.Object;

namespace HouseduinoBackEnd.Helper
{
    public class MessageDbHelper
    {
        string connectionString;
        public MessageDbHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }

        private async Task<ResponseMessageById> GetObjectById(Int32 idValore)
        {
            var response = new ResponseMessageById();

            try
            {
                response.status = 1;
                response.message = "success";

                var query = string.Format(Queries.MESSAGE_GET_BY_ID, idValore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Message();
                    activity.Id = rdr.GetInt32(0);
                    activity.Messaggio = rdr.GetString(1);
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

        public async Task<ResponseMessage> GetLastHour()
        {
            var response = new ResponseMessage();

            response.data = new List<Message>();
            try
            {
                response.status = 1;
                response.message = "success";

                var dtFine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                var dtInizio = DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:ss");
                var query = string.Format(Queries.MESSAGE_GET_LASTHOUR, dtInizio, dtFine);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Message();
                    activity.Id = rdr.GetInt32(0);
                    activity.Messaggio = rdr.GetString(1);
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

        public async Task<ResponseMessageInsert> Insert(RequestMessage request)
        {
            var response = new ResponseMessageInsert();


            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.MESSAGE_POST_DATA, request.messaggio);

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
    }

}

