using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Optional.Serialization
{
    public class OptionalJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var optional = (IOptional)value;

            if (optional.IsSet)
            {
                var t = JToken.FromObject(optional.Value);
                t.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            var isAssignableFrom = false;

            if (objectType.IsGenericType)
            {
                isAssignableFrom = objectType.GetGenericTypeDefinition() == typeof (Optional<>);
            }

            return isAssignableFrom;
        }
    }
}