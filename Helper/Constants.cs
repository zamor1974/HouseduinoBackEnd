

namespace HouseduinoBackEnd.Helper
{

    public class Constants
    {
        public const string DBTYPE = "postgres";
        public const string DBNAME = "arduino";
        public const string DBHOST = "192.168.1.250";
        public const int DBPORT = 5432;
        public const string DBUSERNAME = "arduinoUser";
        public const string DBPASSWORD = "arduinoPassword";
        public const string CURRENTLANG = "it";
    }
    public class Queries
    {
        public const string ALTITUDE_GET = "SELECT id, valore, data_inserimento FROM altitudine order by id desc limit 100";
        public const string ALTITUDE_GET_LAST = "SELECT id, valore, data_inserimento FROM altitudine where id = (select max(id) from altitudine)";
        public const string ALTITUDE_GET_LASTHOUR = "SELECT id,valore,data_inserimento FROM altitudine where data_inserimento  >= '{0}' AND data_inserimento <= '{1}'";
        public const string ALTITUDE_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM altitudine ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string ALTITUDE_POST_DATA = "insert into altitudine (valore,data_inserimento) values ({0},CURRENT_TIMESTAMP) RETURNING id";
        public const string ALTITUDE_GET_BY_ID = "SELECT id, valore, data_inserimento FROM altitudine where id = {0}";

        public const string ACTIVITY_ISACTIVE = "select count(id) as contatore from attivita where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '1 MINUTES'";
        public const string ACTIVITY_GET = "SELECT id,0, data_inserimento FROM attivita order by id desc limit 100";
        public const string ACTIVITY_GET_LAST = "SELECT id, 0, data_inserimento FROM attivita where id = (select max(id) from attivita)";
        public const string ACTIVITY_GET_LASTHOUR = "SELECT id,0, data_inserimento FROM attivita where data_inserimento  >= '{0}' AND data_inserimento <= '{1}'";
        public const string ACTIVITY_INSERT = "insert into attivita (data_inserimento) values (CURRENT_TIMESTAMP) RETURNING id";
        public const string ACTIVITY_GET_BY_ID = "SELECT id, 0, data_inserimento FROM attivita where id = {0}";

        public const string MESSAGE_GET_LAST = "SELECT id, messaggio, data_inserimento FROM messaggio where id = (select max(id) from attivita)";
        public const string MESSAGE_GET_LASTHOUR = "SELECT id,messaggio, data_inserimento FROM messaggio where data_inserimento  >= '{0}' AND data_inserimento <= '{1}'";
        public const string MESSAGE_POST_DATA = "insert into messaggio (messaggio,data_inserimento) values ('{0}',CURRENT_TIMESTAMP) RETURNING id";
        public const string MESSAGE_GET_BY_ID = "SELECT id, messaggio, data_inserimento FROM messaggio where id = {0}";

        public const string RAIN_GET = "SELECT id, valore, data_inserimento FROM pioggia order by id desc limit 100";
        public const string RAIN_GET_LAST = "SELECT id, valore, data_inserimento FROM pioggia where id = (select max(id) from pioggia)";
        public const string RAIN_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM pioggia where data_inserimento  >= >= '{0}' AND data_inserimento <= '{1}'";
        public const string RAIN_POST_DATA = "insert into pioggia (valore,data_inserimento) values ({0},CURRENT_TIMESTAMP) RETURNING id";
        public const string RAIN_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM pioggia ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string RAIN_GET_BY_ID = "SELECT id, valore, data_inserimento FROM pioggia where id = {0}";

        public const string PRESSURE_GET = "SELECT id, valore, data_inserimento FROM pressione order by id desc limit 100";
        public const string PRESSURE_GET_LAST = "SELECT id, valore, data_inserimento FROM pressione where id = (select max(id) from pressione)";
        public const string PRESSURE_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM pressione where data_inserimento  >= '{0}' AND data_inserimento <= '{1}'";
        public const string PRESSURE_POST_DATA = "insert into pressione (valore,data_inserimento) values ({0},CURRENT_TIMESTAMP) RETURNING id";
        public const string PRESSURE_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM pressione ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string PRESSURE_GET_BY_ID = "SELECT id, valore, data_inserimento FROM pressione where id = {0}";

        public const string TEMPERATURE_GET = "SELECT id, valore, data_inserimento FROM temperatura order by id desc limit 100";
        public const string TEMPERATURE_GET_LAST = "SELECT id, valore, data_inserimento FROM temperatura where id = (select max(id) from temperatura)";
        public const string TEMPERATURE_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM temperatura where data_inserimento >= '{0}' AND data_inserimento <= '{1}'";
        public const string TEMPERATURE_POST_DATA = "insert into temperatura (valore,data_inserimento) values ({0},CURRENT_TIMESTAMP) RETURNING id";
        public const string TEMPERATURE_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM temperatura ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string TEMPERATURE_GET_BY_ID = "SELECT id, valore, data_inserimento FROM temperatura where id = {0}";

        public const string HUMIDITY_GET = "SELECT id, valore, data_inserimento FROM umidita order by id desc limit 100";
        public const string HUMIDITY_GET_LAST = "SELECT id, valore, data_inserimento FROM umidita where id = (select max(id) from umidita)";
        public const string HUMIDITY_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM umidita where data_inserimento  >= '{0}' AND data_inserimento <= '{1}'";
        public const string HUMIDITY_POST_DATA = "insert into umidita (valore,data_inserimento) values ({0},CURRENT_TIMESTAMP) RETURNING id";
        public const string HUMIDITY_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM umidita ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string HUMIDITY_GET_BY_ID = "SELECT id, valore, data_inserimento FROM umidita where id = {0}";

        public const string PLANT_GET = "SELECT id, nome, data_inserimento FROM pianta order by id asc";
        public const string PLANT_GET2 = "SELECT id, nome, data_inserimento FROM pianta where id={0} order by id asc";
        public const string PLANT_HUMIDITY_GET = "SELECT id, id_pianta, valore, data_inserimento FROM pianta_umidita  where id_pianta ={0}  order by id desc limit 100";
        public const string PLANT_HUMIDITY_GET_LAST = "SELECT id, id_pianta, valore, data_inserimento FROM pianta_umidita where id = (select max(id) from pianta_umidita where id_pianta={0})";
        public const string PLANT_HUMIDITY_GET_LAST_HOUR = "SELECT id, id_pianta,valore,data_inserimento FROM pianta_umidita where id_pianta ={2} and data_inserimento  >= '{0}' AND data_inserimento <= '{1}'";
        public const string PLANT_HUMIDITY_GET_LAST_VALUE = "select pu.id, p.nome,pu.valore ,pu.data_inserimento  from pianta p join pianta_umidita pu on p.id =pu.id_pianta  where pu.id=(select max(id) from pianta_umidita where id_pianta={0})";
        public const string PLANT_HUMIDITY_POST_DATA = "insert into pianta_umidita (id_pianta,valore) values ({0},{1}) RETURNING id";
        public const string PLANT_HUMIDITY_GET_SHOWDATA = "WITH t AS (SELECT id, id_pianta,valore,data_inserimento FROM pianta_umidita  where id_pianta ={0} ORDER BY data_inserimento DESC LIMIT {1}) SELECT id, id_pianta,valore,data_inserimento FROM t  where id_pianta ={0} ORDER BY data_inserimento ASC";
        public const string PLANT_GET_BY_ID = "SELECT id, nome, data_inserimento FROM pianta where id = {0}";

        public const string AIRQUALITY_GET = "SELECT id, valore, is_valore, data_inserimento FROM qualita_aria order by id desc limit 100";
        public const string AIRQUALITY_GET_LAST = "SELECT id, valore, is_valore, data_inserimento FROM qualita_aria where id = (select max(id) from qualita_aria)";
        public const string AIRQUALITY_GET_LAST_HOUR = "SELECT id,valore, is_valore,data_inserimento FROM qualita_aria where data_inserimento >= '{0}' AND data_inserimento <= '{1}'";
        public const string AIRQUALITY_POST_DATA = "insert into qualita_aria (valore,is_valore,data_inserimento) values ({0},{1},CURRENT_TIMESTAMP) RETURNING id";
        public const string AIRQUALITY_GET_SHOWDATA = "WITH t AS (SELECT id,valore,is_valore,data_inserimento FROM qualita_aria ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,is_valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string AIRQUALITY_GET_BY_ID = "SELECT id, valore,is_valore, data_inserimento FROM qualita_aria where id = {0}";

        public const string LIGHTNESS_GET = "SELECT id, valore, data_inserimento FROM luminosita order by id desc limit 100";
        public const string LIGHTNESS_GET_LAST = "SELECT id, valore, data_inserimento FROM luminosita where id = (select max(id) from luminosita)";
        public const string LIGHTNESS_GET_LAST_HOUR = "SELECT id,valore,data_inserimento FROM luminosita where data_inserimento >= '{0}' AND data_inserimento <= '{1}'";
        public const string LIGHTNESS_POST_DATA = "insert into luminosita (valore,data_inserimento) values ({0},CURRENT_TIMESTAMP) RETURNING id";
        public const string LIGHTNESS_GET_SHOWDATA = "WITH t AS (SELECT id,valore,data_inserimento FROM luminosita ORDER BY data_inserimento DESC LIMIT {0}) SELECT id,valore,data_inserimento FROM t ORDER BY data_inserimento ASC";
        public const string LIGHTNESS_GET_BY_ID = "SELECT id, valore, data_inserimento FROM luminosita where id = {0}";

        public const string MOTOR_GET_ALL = "SELECT id, nome, data_inserimento FROM pianta order by id asc";
        public const string MOTOR_GET = "select pu.valore from pianta_umidita pu where pu.id =(select max(pu.id) from pianta_umidita pu where pu.id_pianta =%s and pu.data_inserimento > current_timestamp  -INTERVAL '10 MINUTE')";

        public const string PREVISION_GET = "select 'TIPO PRESSIONE' as Dato, case when round(valore)>1013 then 'ALTA PRESSIONE' else 'BASSA PRESSIONE' end as Valore from  pressione where  id = (select max(id) from pressione) union select 'PRESSIONE MINIMA' as Dato, cast(min(round(valore)) as varchar) as Valore from   (select * from pressione where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t union select 'PRESSIONE MASSIMA' as Dato, cast(max(round(valore)) as varchar) as Valore from  (select * from pressione where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t union select 'TEMPERATURA MINIMA' as Dato, cast(min(round(valore)) as varchar) as Valore from  (select * from temperatura where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t union select 'TEMPERATURA MASSIMA' as Dato,cast(max(round(valore)) as varchar) as Valore from (select * from temperatura where  data_inserimento <=now() and data_inserimento >= now() - INTERVAL '3 HOURS') t";

    }
}