using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Net6JsonCusomSerialize;

internal static class JsonHelper
{
  public static string CustomSerialize<T>(T instance)
  {
    // 客製序列化
    var settings = new JsonSerializerSettings
    {
      ContractResolver = new CustomContractResolver(),
      Formatting = Formatting.Indented
    };

    string json = JsonConvert.SerializeObject(instance, settings);
    return json;
  }

  class CustomContractResolver : DefaultContractResolver
  {
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
      JsonProperty property = base.CreateProperty(member, memberSerialization);

      // 自訂屬性名稱
      DisplayAttribute dispAttr = (DisplayAttribute)member.GetCustomAttribute(typeof(DisplayAttribute));
      if (dispAttr != null)
      {
        property.PropertyName = dispAttr.Name;
      }

      // 自訂屬性名稱
      DisplayNameAttribute nameAttr = (DisplayNameAttribute)member.GetCustomAttribute(typeof(DisplayNameAttribute));
      if (nameAttr != null)
      {
        property.PropertyName = nameAttr.DisplayName;
      }

      return property;
    }
  }
}
