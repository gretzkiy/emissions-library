using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Sensor
    {
        // Уникальный идентификатор датчика
        public string sensorUuid;

        // Состояние датчика {OK, ERROR, MAINTENANCE}
        public string state;

        // Уникальный идентификатор источника выбросов, на котором расположен данный сенсор
        public string sourceUuid;

        public Sensor()
        {
            sensorUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Датчик " + sensorUuid;
        }

        // Получение списка всех датчиков из базы данных
        public static List<Sensor> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Sensors;";
                return connection.Query<Sensor>(sqlQuery).ToList();
            }
        }

        // Получение списка параметров, измеряемых одним датчиком
        public static List<Parameter> GetParameters(string connectionString, string sensorUuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Parameters Param WHERE Param.sensorUuid = @sensorUuid;";
                return connection.Query<Parameter>(sqlQuery, new { sensorUuid }).ToList();
            }
        }

        // Сохранение нового датчика в базу данных
        public static void Create(string connectionString, Sensor sensor)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Sensors (sensorUuid, state, sourceUuid)" +
                    " VALUES (@sensorUuid, @state, @sourceUuid);";

                connection.Execute(sqlQuery, sensor);
            }
        }
    }
}
