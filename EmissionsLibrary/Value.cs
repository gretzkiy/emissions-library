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
        public string valueUuid { get; set; }

        // Временные отметки усреднения значения показания
        public int timestampStart { get; set; }
        public int timestampEnd { get; set; }

        // Значение показания
        public string value { get; set; }

        // Уникальный идентификатор параметра
        public string parameterUuid { get; set; }

        // Название таблицы в БД
        public const string tableName = "Results";

        public Value()
        {
            valueUuid = Guid.NewGuid().ToString();
            timestampEnd = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        // Получение списка всех значений из базы данных
        public static List<Value> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName};";
                return connection.Query<Value>(sqlQuery).ToList();
            }
        }

        // Сохранение нового значения в базу данных
        public static void Create(string connectionString, Value value)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO {tableName} (valueUuid, timestampStart, timestampEnd, value, parameterUuid)" +
                    " VALUES (@valueUuid, @timestampStart, @timestampEnd, @value, @parameterUuid);";

                connection.Execute(sqlQuery, value);
            }
        }
    }
}
