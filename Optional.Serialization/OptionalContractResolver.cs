using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Optional.Serialization
{
    public class OptionalContractResolver : DefaultContractResolver
    {
        public new static readonly OptionalContractResolver Instance = new OptionalContractResolver();
 
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);

            if (objectType.IsGenericType)
            {
                var typeDefinition = objectType.GetGenericTypeDefinition();

                if (typeDefinition == typeof(Optional<>))
                {
                    contract.Converter = new OptionalJsonConverter();
                }
            }

            return contract;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType.IsGenericType)
            {
                var typeDefinition = property.PropertyType.GetGenericTypeDefinition();

                if (typeDefinition == typeof(Optional<>))
                {
                    property.ShouldSerialize =
                        instance =>
                        {
                            var o = (IOptional)property.ValueProvider.GetValue(instance);
                            return o.IsSet;
                        };
                }
            }

            return property;
        }
    }
}