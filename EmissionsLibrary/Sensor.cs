using System;
using System.Collections.Generic;
using System.Text;

namespace EmissionsLibrary
{
    public enum State { OK, ERROR, MAINTENANCE };

    public class Sensor
    {
        // Уникальный идентификатор датчика
        public string sensorUuid;

        // Состояние датчика {OK, ERROR, MAINTENANCE}
        public State state;

        // Показатели (параметры), которые измеряет датчик
        public Parameter[] parameters;

        public Sensor() { }

        public Sensor(State _state)
        {
            state = _state;
            sensorUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Датчик " + sensorUuid;
        }
    }
}
