using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bell.WebApi.Json
{
    /// <summary>
    /// TODO: See if this is needed, in practice.  It looks like this is not necessary!
    /// </summary>
    public class CustomContractResolver : DefaultContractResolver
    {
        private static readonly InterfaceJsonConverter _converter = new InterfaceJsonConverter();

        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (objectType == null || !objectType.GetTypeInfo().IsInterface)
            {
                return base.ResolveContractConverter(objectType);
            }

            return _converter;
        }
    }
}
