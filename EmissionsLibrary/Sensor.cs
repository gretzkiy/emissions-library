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

        // Получение списка всех сенсоров из базы данных
        public static List<Sensor> Get(IDbConnection connection)
        {
            using (connection)
            {
                var sqlQuery = "SELECT * FROM Sensors;";
                return connection.Query<Sensor>(sqlQuery).ToList();
            }
        }

        // Получение списка параметров, измеряемых одним датчиком
        public static List<Parameter> GetParameters(IDbConnection connection, string sensorUuid)
        {
            using (connection)
            {
                var sqlQuery = "SELECT * FROM Parameters Param WHERE Param.sensorUuid = @sensorUuid;";
                return connection.Query<Parameter>(sqlQuery, new { sensorUuid }).ToList();
            }
        }

        // Сохранение нового значения в базу данных
        public static void Create(IDbConnection connection, Sensor sensor)
        {
            using (connection)
            {
                var sqlQuery = "INSERT INTO Sensors (sensorUuid, state, sourceUuid)" +
                    " VALUES (@sensorUuid, @state, @sourceUuid);";

                connection.Execute(sqlQuery, sensor);
            }
        }
    }
}
