using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmissionsLibrary
{
    public class Parameter
    {
        // Уникальный идентификатор показания
        public string parameterUuid;

        // Тип показания
        public string code;

        // Единица измерения показания
        public string unit;

        // Тип данных показания
        public string type;

        // Уникальный идентификатор сенсора
        public string sensorUuid;

        public Parameter()
        {
            parameterUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Показатель " + code;
        }

        // Получение списка всех параметров из базы данных
        public static List<Parameter> Get(IDbConnection connection)
        {
            using (connection)
            {
                var sqlQuery = "SELECT * FROM Parameters;";
                return connection.Query<Parameter>(sqlQuery).ToList();
            }
        }

        // Получение списка значений для одного параметра
        public static List<Value> GetValues(IDbConnection connection, string parameterUuid)
        {
            using (connection)
            {
                var sqlQuery = "SELECT * FROM Values Val WHERE Val.parameterUuid = @parameterUuid;";
                return connection.Query<Value>(sqlQuery, new { parameterUuid }).ToList();
            }
        } 

        // Сохранение нового значения в базу данных
        public static void Create(IDbConnection connection, Parameter parameter)
        {
            using (connection)
            {
                var sqlQuery = "INSERT INTO Parameters (parameterUuid, code, unit, type, sensorUuid)" +
                    " VALUES (@parameterUuid, @code, @unit, @type, @sensorUuid);";

                connection.Execute(sqlQuery, parameter);
            }
        }
    }
}
