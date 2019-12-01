using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Value
    {
        // Уникальный идентификатор значения показания
        public string valueUuid;

        // Временные отметки усреднения значения показания
        public int timestampStart, timestampEnd;

        // Значение показания
        public string value;

        // Уникальный идентификатор параметра
        public string parameterUuid;

        public Value()
        {
            valueUuid = Guid.NewGuid().ToString();
            timestampStart = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            timestampEnd = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        // Получение списка всех значений из базы данных
        public static List<Value> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Values;";
                return connection.Query<Value>(sqlQuery).ToList();
            }
        }

        // Сохранение нового значения в базу данных
        public static void Create(string connectionString, Value value)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Values (valueUuid, timestampStart, timestampEnd, value, parameterUuid)" +
                    " VALUES (@valueUuid, @timestampStart, @timestampEnd, @value, @parameterUuid);";

                connection.Execute(sqlQuery, value);
            }
        }
    }
}
