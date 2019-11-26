using System;
using System.Collections.Generic;
using System.Text;

namespace EmissionsLibrary
{
    public class Source
    {
        // Уникальный идентификатор источника выбросов
        public string sourceUuid;

        // Порядковый номер источника выбросов
        public int pniv;

        // Датчики, установленные на источнике выбросов
        public Sensor[] sensors = new Sensor[] { };

        public Source()
        {
            sourceUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Источник №" + pniv.ToString();
        }
    }
}
