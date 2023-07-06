# Net6JsonCusomSerialize
 JSON 客製序列化 for 特殊應用

# 環境
* 平台：.NET6
* IDE: Visual Studio 2022

# 為了特殊的應用 JSON 序列化應用
情境：原本欄位名稱為英文，改成序列化成中文名稱。   
規格：客製 JSON 序列化時，欄位名稱改取自 DispalyNameAttribute 指定的欄位名稱。
實作時發現 System.Text.Json 客製化能做的太有限。只好改用 Newtonsoft.Json 果然立馬滿足。Newtonsoft.Json 紅了這麼多年是有理由的。

### 一般 JSON 序列化
```JSON
formContent =>
{
  "FormNo": "F001",
  "FormTitle": "我是抬頭",
  "FormValue": 9876543210.1234,
  "UpdDtm": "2023-07-06T19:41:05.2193539+08:00",
  "Detail": {
    "DetailNo": 998,
    "DetailTitle": "就是這麼簡單"
  },
  "ItemList": [
    {
      "ItemNo": 1,
      "ItemTitle": "我是第一項"
    },
    {
      "ItemNo": 1,
      "ItemTitle": "我是第二項"
    }
  ]
}
```

### 特殊應用 JSON 序列化，
透過客製化改取 DispalyNameAttribute 指定的欄位名稱。
```JSON
formContent =>
{
  "表單號碼": "F001",
  "表單抬頭": "我是抬頭",
  "表單數值": 9876543210.1234,
  "異動時間": "2023-07-06T19:41:05.2193539+08:00",
  "明細內容": {
    "明細號碼": 998,
    "明細抬頭": "就是這麼簡單"
  },
  "項目清冊": [
    {
      "項目號碼": 1,
      "項目抬頭": "我是第一項"
    },
    {
      "項目號碼": 1,
      "項目抬頭": "我是第二項"
    }
  ]
}
```
