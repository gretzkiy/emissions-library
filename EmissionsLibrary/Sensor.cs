using System;
using System.Collections.Generic;
using System.Text;

namespace EmissionsLibrary
{
    public class Sensor
    {
        // Уникальный идентификатор датчика
        public string sensorUuid;

        // Состояние датчика {OK, ERROR, MAINTENANCE}
        public string state;

        // Показатели (параметры), которые измеряет датчик
        public Parameter[] parameters = new Parameter[] { };

        public Sensor()
        {
            sensorUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Датчик " + sensorUuid;
        }
    }
}
