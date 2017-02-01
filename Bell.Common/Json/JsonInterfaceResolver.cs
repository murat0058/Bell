using System;
using DryIoc;
using Newtonsoft.Json.Converters;
using Bell.Common.DryIoc;
using Bell.Common.Exceptions;
using Bell.Common.Resources;
using System.Reflection;

namespace Bell.Json
{
    /// <summary>
    /// Creates concrete objects for the interfaces specified
    /// </summary>
    /// <typeparam name="TObjectType">The interface to resolve</typeparam>
    public class JsonInterfaceResolver<TObjectType> : CustomCreationConverter<TObjectType> where TObjectType : class
    {
        /// <summary>
        /// Creates a concrete object, based on the interface or class object type
        /// </summary>
        /// <param name="objectType">The type of object</param>
        /// <returns>A concrete representation of this object</returns>
        public override TObjectType Create(Type objectType)
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

            var resolvedObject = DryIocConfiguration.Container.Resolve<TObjectType>();
            return resolvedObject as TObjectType;
        }
    }
}