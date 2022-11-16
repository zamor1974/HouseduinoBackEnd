using System;
using HouseduinoBackEnd.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Object = HouseduinoBackEnd.Models.Object;

namespace HouseduinoBackEnd.Helper
{
    public class PlantDbHelper
    {
        string connectionString;
        public PlantDbHelper()
        {
            connectionString = $"Host={Constants.DBHOST};port={Constants.DBPORT}; Username={Constants.DBUSERNAME};Password={Constants.DBPASSWORD}; Database={Constants.DBNAME}";
            //connectionString = $"host={Constants.DBHOST} port={Constants.DBPORT} user={Constants.DBUSERNAME} password={Constants.DBPASSWORD} dbname={Constants.DBNAME} sslmode=disable";
        }

        public async Task<ResponsePlant> GetAll()
        {
            var response = new ResponsePlant();

            response.data = new List<Plant>();
            try
            {
                response.status = 1;
                response.message = "success";

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(Queries.PLANT_GET);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Plant();
                    activity.Id = rdr.GetInt32(0);
                    activity.Nome = rdr.GetString(1);
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

        public async Task<ResponsePlant> GetPlantStatus()
        {
            var response = new ResponsePlant();

            response.data = new List<Plant>();
            try
            {
                response.status = 1;
                response.message = "success";
                var tuttePiante = new List<Plant>();

                var piante = GetAll().Result.data;

                foreach (var pianta in piante)
                {
                    var query = string.Format(Queries.PLANT_HUMIDITY_GET_LAST_VALUE, pianta.Id);

                    await using var dataSource = NpgsqlDataSource.Create(connectionString);
                    await using var command = dataSource.CreateCommand(query);
                    await using var rdr = await command.ExecuteReaderAsync();

                    while (await rdr.ReadAsync())
                    {
                        var activity = new Plant();
                        activity.Id = rdr.GetInt32(0);
                        activity.Nome = rdr.GetString(1);
                        activity.Valore = rdr.GetDouble(2);
                        activity.DateInsert = rdr.GetFieldValue<DateTime>(3);

                        tuttePiante.Add(activity);
                    }
                }

                response.data = tuttePiante;
   
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        private async Task<ResponsePlantById> GetPlantById(Int32 idValore)
        {
            var response = new ResponsePlantById();

            try
            {
                response.status = 1;
                response.message = "success";

                var query = string.Format(Queries.PLANT_GET_BY_ID, idValore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Plant();
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

        public async Task<ResponsePlant> GetAllByPlant(int idPianta)
        {
            var pianta = GetPlantById(idPianta).Result.data;

            var response = new ResponsePlant();

            response.data = new List<Plant>();
            try
            {
                response.status = 1;
                response.message = "success";

                var query = string.Format(Queries.PLANT_HUMIDITY_GET, idPianta);
                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Plant();
                    activity.Id = rdr.GetInt32(0);
                    activity.Nome = pianta.Nome;
                    activity.Valore = rdr.GetDouble(2);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(3);

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

        public async Task<ResponsePlant> GetLastHourByPlant(int idPianta)
        {
            var pianta = GetPlantById(idPianta).Result.data;

            var response = new ResponsePlant();

            response.data = new List<Plant>();
            try
            {
                response.status = 1;
                response.message = "success";

                var dtFine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                var dtInizio = DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:ss");
                var query = string.Format(Queries.PLANT_HUMIDITY_GET_LAST_HOUR,dtInizio,dtFine, idPianta);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Plant();
                    activity.Id = rdr.GetInt32(0);
                    activity.Nome = pianta.Nome;
                    activity.Valore = rdr.GetDouble(2);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(3);

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

        public async Task<ResponsePlant> GetLastByPlant(int idPianta)
        {
            var pianta = GetPlantById(idPianta).Result.data;

            var response = new ResponsePlant();

            response.data = new List<Plant>();
            try
            {
                response.status = 1;
                response.message = "success";

                var dtFine = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                var dtInizio = DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:ss");
                var query = string.Format(Queries.PLANT_HUMIDITY_GET_LAST, dtInizio, dtFine, idPianta);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Plant();
                    activity.Id = rdr.GetInt32(0);
                    activity.Nome = pianta.Nome;
                    activity.Valore = rdr.GetDouble(2);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(3);

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

        public async Task<ResponsePlantInsert> Insert(RequestPlant request)
        {
            var response = new ResponsePlantInsert();


            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.PLANT_HUMIDITY_POST_DATA, request.Id, request.valore);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                Int32 rdr = (Int32)await command.ExecuteScalarAsync();
                var idValore = rdr;

                var responseById = GetLastByPlant(request.Id);
                var elems = responseById.Result.data;
                response.data = elems.ToArray()[0];

            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;
            }


            return response;
        }

        public async Task<ResponsePlant> GetShowDataByPlant(int idPianta,int recordNumber)
        {
            var pianta = GetPlantById(idPianta).Result.data;
            var response = new ResponsePlant();

            response.data = new List<Plant>();
            try
            {
                response.status = 1;
                response.message = "success";
                var query = string.Format(Queries.PLANT_HUMIDITY_GET_SHOWDATA, idPianta, recordNumber);

                await using var dataSource = NpgsqlDataSource.Create(connectionString);
                await using var command = dataSource.CreateCommand(query);
                await using var rdr = await command.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    var activity = new Plant();
                    activity.Id = rdr.GetInt32(0);
                    activity.Nome = pianta.Nome;
                    activity.Valore = rdr.GetDouble(2);
                    activity.DateInsert = rdr.GetFieldValue<DateTime>(3);

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

