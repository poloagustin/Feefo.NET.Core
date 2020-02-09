﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Feefo.Core.JsonConverters
{
    public class SingleValueArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<List<T>>(reader);
            }
            else
            {
                var media = serializer.Deserialize<T>(reader);
                return new List<T>(new[] { media });
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
