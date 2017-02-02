using System;
using Newtonsoft.Json.Serialization;

namespace Bell.Common.Json
{
    public class CamelCasePropertyNamesExceptDictionaryKeysContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var dictionaryContract = base.CreateDictionaryContract(objectType);
            dictionaryContract.DictionaryKeyResolver = propertyName => propertyName;
            return dictionaryContract;
        }
    }
}