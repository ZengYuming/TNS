using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TNS.MVC4.Common
{
    public static class RequestHelper<T> where T : class
    {
        public static void RequestPropertys(HttpRequestBase request, ref T entity)
        {
            Type myType = typeof(T);
            //BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic 
            PropertyInfo[] myPropertys = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in myPropertys)
            {
                if (propertyInfo.Name.Contains("System.Collections.Generic."))
                    continue;
                var value = request[propertyInfo.Name];
                if (value == null || string.IsNullOrWhiteSpace(value)) continue;
                if (propertyInfo.PropertyType != typeof(string))
                {
                    try
                    {
                        var obj = ChangeType(value, propertyInfo.PropertyType);
                        propertyInfo.SetValue(entity, obj, null);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                else
                {
                    propertyInfo.SetValue(entity, value, null);
                }
            }
        }
        public static void RequestQueryStringPropertys(HttpRequestBase request, ref T entity)
        {
            Type myType = typeof(T);
            //BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic 
            PropertyInfo[] myPropertys = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in myPropertys)
            {
                if (propertyInfo.Name.Contains("System.Collections.Generic."))
                    continue;
                var value = request.QueryString[propertyInfo.Name];
                if (value == null || string.IsNullOrWhiteSpace(value)) continue;
                if (propertyInfo.PropertyType != typeof(string))
                {
                    try
                    {
                        var obj = ChangeType(value, propertyInfo.PropertyType);
                        propertyInfo.SetValue(entity, obj, null);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }
                else
                {
                    propertyInfo.SetValue(entity, value, null);
                }
            }
        }
        public static object ChangeType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType &&
                conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                    return null;
                var nullableConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else if (conversionType.Name == "Guid")
            {
                return new Guid(value.ToString());
            }
            return Convert.ChangeType(value, conversionType);
        }


    }
}