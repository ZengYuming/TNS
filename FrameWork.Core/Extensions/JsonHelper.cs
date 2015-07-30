using System;
using Newtonsoft.Json;

namespace Framework.Core.Extensions
{
    public static class JsonHelper
    {
        public static string JsonSerialize(this object val)
        {
            return JsonConvert.SerializeObject(val);
        }
        public static object JsonDeserialize(this string val)
        {
            return JsonConvert.DeserializeObject(val);
        }
        public static T JsonDeserialize<T>(this string val)
        {
            return JsonConvert.DeserializeObject<T>(val);
        }
    }
}
