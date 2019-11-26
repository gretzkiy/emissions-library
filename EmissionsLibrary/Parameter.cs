using System;
using System.Collections.Generic;
using System.Text;

namespace EmissionsLibrary
{
    public class Parameter
    {
        // Уникальный идентификатор показания
        public readonly string parameterUuid;

        // Тип показания
        public string code;

        // Единица измерения показания
        public string unit;

        // Тип данных показания
        public string type;

        // Значения измерений
        public Value[] values;

        public Parameter()
        {
            parameterUuid = Guid.NewGuid().ToString();
        }
    }
}
