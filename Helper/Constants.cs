

namespace HouseduinoBackEnd.Helper{

    public class Constants{
        public const string DBTYPE = "postgres";
        public const string DBNAME = "arduino";
        public const string DBHOST = "192.168.1.250";
        public const int DBPORT = 5432;
        public const string DBUSERNAME = "arduinoUser";
        public const string DBPASSWORD = "arduinoPassword";
        public const string CURRENTLANG = "it";
    }
    public class Queries{
        public const string TEMPERATURE_GET = "SELECT id, valore, data_inserimento FROM temperatura order by id desc limit 100";
        public const string TEMPERATURE_GET_LAST = "SELECT id, valore, data_inserimento FROM temperatura where id = (select max(id) from temperatura)";
        public const string TEMPERATURE_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM temperatura where data_inserimento  >= '%s' AND data_inserimento <= '%s'";
        public const string TEMPERATURE_POST_DATA = "insert into temperatura (valore,data_inserimento) values (%.2f,CURRENT_TIMESTAMP) RETURNING id";
        public const string TEMPERATURE_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM temperatura ORDER BY data_inserimento DESC LIMIT %d) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";

        public const string HUMIDITY_GET = "SELECT id, valore, data_inserimento FROM umidita order by id desc limit 100";
        public const string HUMIDITY_GET_LAST = "SELECT id, valore, data_inserimento FROM umidita where id = (select max(id) from umidita)";
        public const string HUMIDITY_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM umidita where data_inserimento  >= '%s' AND data_inserimento <= '%s'";
        public const string HUMIDITY_POST_DATA = "insert into umidita (valore,data_inserimento) values (%.2f,CURRENT_TIMESTAMP) RETURNING id";
        public const string HUMIDITY_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM umidita ORDER BY data_inserimento DESC LIMIT %d) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";

        public const string PLANT_GET = "SELECT id, nome, data_inserimento FROM pianta order by id asc";
        public const string PLANT_HUMIDITY_GET = "SELECT id, id_pianta, valore, data_inserimento FROM pianta_umidita  where id_pianta =%s  order by id desc limit 100";
        public const string PLANT_HUMIDITY_GET_LAST = "SELECT id, id_pianta, valore, data_inserimento FROM pianta_umidita where id = (select max(id) from pianta_umidita where id_pianta=%s)";
        public const string PLANT_HUMIDITY_GET_LAST_HOUR = "SELECT id, id_pianta,valore,data_inserimento FROM pianta_umidita where id_pianta =%s and data_inserimento  >= '%s' AND data_inserimento <= '%s'";
        public const string PLANT_HUMIDITY_GET_LAST_VALUE = "select pu.id, p.nome,pu.valore ,pu.data_inserimento  from pianta p join pianta_umidita pu on p.id =pu.id_pianta  where pu.id=(select max(id) from pianta_umidita where id_pianta=%s)";
        public const string PLANT_HUMIDITY_POST_DATA = "insert into pianta_umidita (id_pianta,valore,data_inserimento) values (%s,%.2f,CURRENT_TIMESTAMP) RETURNING id";
        public const string PLANT_HUMIDITY_GET_SHOWDATA = "WITH t AS (SELECT id, id_pianta,valore,data_inserimento FROM pianta_umidita  where id_pianta =%s ORDER BY data_inserimento DESC LIMIT %d) SELECT id, id_pianta,valore,data_inserimento FROM t  where id_pianta =%s ORDER BY data_inserimento ASC";

        public const string PREVISION_GET = "select 'TIPO PRESSIONE' as Dato, case when round(valore)>1013 then 'ALTA PRESSIONE' else 'BASSA PRESSIONE' end as Valore from  pressione where  id = (select max(id) from pressione) union select 'PRESSIONE MINIMA' as Dato, cast(min(round(valore)) as varchar) as Valore from   (select * from pressione where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t union select 'PRESSIONE MASSIMA' as Dato, cast(max(round(valore)) as varchar) as Valore from  (select * from pressione where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t union select 'TEMPERATURA MINIMA' as Dato, cast(min(round(valore)) as varchar) as Valore from  (select * from temperatura where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t union select 'TEMPERATURA MASSIMA' as Dato,cast(max(round(valore)) as varchar) as Valore from (select * from temperatura where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t";

    }
}