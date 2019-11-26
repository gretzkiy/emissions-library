using System;

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

        public Value()
        {
            valueUuid = Guid.NewGuid().ToString();
            timestampStart = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            timestampEnd = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
