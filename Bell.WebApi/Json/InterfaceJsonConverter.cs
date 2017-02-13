using System;
using Newtonsoft.Json;
using System.Reflection;
using Bell.Common.DryIoc;
using Bell.Common.Exceptions;
using Bell.Common.Resources;

namespace Bell.WebApi.Json
{
    public class InterfaceJsonConverter : JsonConverter
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter"/> can write JSON
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="JsonConverter"/> can write JSON; otherwise, <c>false</c>
        /// </value>
        public override bool CanWrite
        {
            get { return true; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Writes the JSON representation of the object
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to</param>
        /// <param name="value">The value</param>
        /// <param name="serializer">The calling serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        /// <summary>
        /// Reads the JSON representation of the object
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from</param>
        /// <param name="objectType">Type of the object</param>
        /// <param name="existingValue">The existing value of object being read</param>
        /// <param name="serializer">The calling serializer</param>
        /// <returns>The object value</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = CreateObject(objectType);

            if (value == null)
            {
                throw new ArgumentNullException();
            }

           serializer.Populate(reader, value);
           
            return value;
        }

        /// <summary>
        /// Creates an object which will then be populated by the serializer
        /// </summary>
        /// <param name="objectType">Type of the object</param>
        /// <returns>The created object</returns>
        public object CreateObject(Type objectType)
        {
            if (DryIocConfiguration.Container == null)
            {
                throw new BellCommonException(
                    ErrorMessageKeys.DRYIOC_CONFIGURATION_CONTAINER_SHOULD_NOT_BE_NULL);
            }

            if (!objectType.GetTypeInfo().IsInterface)
            {
                throw new BellCommonException(ErrorMessageKeys.OBJECT_TYPE_SHOULD_BE_AN_INTERFACE);
            }

            return DryIocConfiguration.Container.Resolve(objectType, true);
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type
        /// </summary>
        /// <param name="objectType">Type of the object</param>
        /// <returns>
        /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsInterface;
        }

        #endregion
    }
}
