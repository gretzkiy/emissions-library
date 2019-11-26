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
        public Sensor[] sensors;

        public Source() { }

        public Source(int _pniv)
        {
            pniv = _pniv;
            sourceUuid = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return "Источник №" + pniv.ToString();
        }
    }
}
