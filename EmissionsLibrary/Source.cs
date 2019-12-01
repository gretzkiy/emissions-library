using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Source
    {
        // Уникальный идентификатор источника выбросов
        public string sourceUuid;

        // Порядковый номер источника выбросов
        public int pniv;

        public Source()
        {
            sourceUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Источник №" + pniv.ToString();
        }

        // Получение списка всех истоников выбросов из базы данных
        public static List<Source> Get(string connectionString)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Sources;";
                return connection.Query<Source>(sqlQuery).ToList();
            }
        }

        // Получение списка датчиков, расположенных на данном источнике выбросов
        public static List<Sensor> GetSensors(string connectionString, string sourceUuid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT * FROM Sensors Snr WHERE Snr.sourceUuid = @sourceUuid;";
                return connection.Query<Sensor>(sqlQuery, new { sourceUuid }).ToList();
            }
        }

        // Сохранение нового значения в базу данных
        public static void Create(string connectionString, Source source)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Sources (sourceUuid, pniv) VALUES (@sourceUuid, @pniv);";

                connection.Execute(sqlQuery, source);
            }
        }
    }
}
