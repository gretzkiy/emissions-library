﻿using System;

namespace EmissionsLibrary
{
    public class Value
    {
        // Уникальный идентификатор значения показания
        public readonly string valueUuid;

        // Временные отметки усреднения значения показания
        public int timestampStart, timestampEnd;

        // Значение показания
        public string value;     // не понятно, какой тип

        public Value()
        {
            valueUuid = Guid.NewGuid().ToString();
            timestampStart = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            timestampEnd = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public override string ToString()
        {
            return value + valueUuid;
        }
    }
}
