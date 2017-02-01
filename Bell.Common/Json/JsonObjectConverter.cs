using Newtonsoft.Json;

namespace Bell.Json
{
    public static class JsonObjectConverter
    {
        public static TToObject Convert<TFromObject, TToObject>(
            TFromObject fromValue, JsonSerializerSettings jsonSerializerSettings)
        {
            var fromJson = JsonConvert.SerializeObject(fromValue, jsonSerializerSettings);
            return JsonConvert.DeserializeObject<TToObject>(fromJson, jsonSerializerSettings);
        }
        public static TToObject Convert<TFromObject, TToObject>(TFromObject fromValue)
        {
            var jsonSerializerSettings = JsonConvert.DefaultSettings();
            var fromJson = JsonConvert.SerializeObject(fromValue, jsonSerializerSettings);
            return JsonConvert.DeserializeObject<TToObject>(fromJson, jsonSerializerSettings);
        }
    }
}