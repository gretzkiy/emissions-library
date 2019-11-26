using System;
using System.Collections.Generic;
using System.Text;

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

        // Значения измерений
        public Value[] values = new Value[] { };

        public Parameter()
        {
            parameterUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Показатель " + code;
        }
    }
}
