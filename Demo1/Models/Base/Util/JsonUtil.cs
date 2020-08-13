using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Demo1.Model.Util
{
    public class JsonUtil
    {

        private static JsonSerializerSettings settings = new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() };

        /// <summary>
        /// MODEL轉成JSON (請勿參照自己，會無法轉換)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        public static ActionResult ToJsonResult(object obj)
        {
            var result = new ContentResult();

            result.ContentType = "application/json";
            result.Content = ToJson(obj);

            return result;
        }

        class NullToEmptyStringResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                return type.GetProperties()
                        .Select(p => {
                            var jp = base.CreateProperty(p, memberSerialization);
                            jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                            return jp;
                        }).ToList();
            }
        }
        
        class NullToEmptyStringValueProvider : Newtonsoft.Json.Serialization.IValueProvider
        {
            PropertyInfo _MemberInfo;
            public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
            {
                _MemberInfo = memberInfo;
            }

            public object GetValue(object target)
            {
                object result = _MemberInfo.GetValue(target);
                if (result == null) result = "";
                return result;

            }

            public void SetValue(object target, object value)
            {
                _MemberInfo.SetValue(target, value);
            }
        }
        
    }
}
