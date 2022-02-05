using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Project_cassa_test.Extench
{
    public static class SessinHelper
    {
        public static void SetObjectAsJson(this ISession session,string key,object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session,string key)
        {
            var value = session.GetString(key);
            return value== null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
