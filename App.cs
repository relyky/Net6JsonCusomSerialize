using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Net6JsonCusomSerialize.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net6JsonCusomSerialize
{
  internal class App
  {
    readonly IConfiguration _config;
    readonly RandomService _randSvc;

    public App(IConfiguration config, RandomService randSvc)
    {
      _config = config;
      _randSvc = randSvc;
    }

    /// <summary>
    /// 取代原本 Program.Main() 函式的效用。
    /// </summary>
    public void Run(string[] args)
    {
      FooForm formData = new FooForm
      {
        FormNo = "F001",
        FormTitle = "我是抬頭",
        FormValue = 9876543210.1234m,
        UpdDtm = DateTime.Now,
        Detail = new FooDetail
        {
          DetailNo = 998,
          DetailTitle = "就是這麼簡單"
        },
        ItemList = new List<FooItem>(new[] {
          new FooItem { ItemNo = 1, ItemTitle = "我是第一項" },
          new FooItem { ItemNo = 1, ItemTitle = "我是第二項" },
        })
      };

      // 一般序列化
      var options = new JsonSerializerOptions()
      {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
      };

      string formContent = System.Text.Json.JsonSerializer.Serialize(formData, options);
      Console.WriteLine(@"formContent => " + formContent);

      // 客製序列化(使用 Newtonsoft.Json 。
      string formContent2 = JsonHelper.CustomSerialize(formData);

      Console.WriteLine(@"formContent2 => " + formContent2);

      // 測試 services injection
      Console.WriteLine("Press any key to continue.");
      Console.ReadKey();
    }
  }

  class FooForm
  {
    [DisplayName("表單號碼")]
    public string FormNo { get; set; }

    [DisplayName("表單抬頭")]
    public string FormTitle { get; set; }

    [DisplayName("表單數值")]
    public decimal FormValue { get; set; }

    [DisplayName("異動時間")]
    public DateTime UpdDtm { get; set; }

    [DisplayName("明細內容")]
    public FooDetail Detail { get; set; }

    [DisplayName("項目清冊")]
    public List<FooItem> ItemList { get; set; }
  }

  class FooDetail
  {
    [DisplayName("明細號碼")]
    public int DetailNo { get; set; }

    [DisplayName("明細抬頭")]
    public string DetailTitle { get; set; }
  }

  class FooItem
  {
    [DisplayName("項目號碼")]
    public int ItemNo { get; set; }

    [DisplayName("項目抬頭")]
    public string ItemTitle { get; set; }
  }
}