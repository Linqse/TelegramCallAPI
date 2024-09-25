# API для Telegram

Этот API предоставляет возможность отправки текстовых сообщений, фотографий и инициации звонков через Telegram с использованием FastAPI и Pyrogram.

## Как пользоваться

Скрипт размещён по адресу: [https://api.eyesquad.net/telegram](https://api.eyesquad.net/telegram).

### Возможные запросы

1. **Отправка текстового сообщения**

   **POST** `/telegram`

   #### Пример на C# (с использованием `HttpClient` и `Newtonsoft.Json`):

   ```csharp
   using System;
   using System.Net.Http;
   using System.Text;
   using System.Threading.Tasks;
   using Newtonsoft.Json;

   class Program
   {
       static async Task Main(string[] args)
       {
           var client = new HttpClient();
           var requestBody = new
           {
               username = "telegram_username",
               text = "Привет!"
           };

           var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

           var response = await client.PostAsync("https://api.eyesquad.net/telegram", content);
           var responseString = await response.Content.ReadAsStringAsync();
           
           Console.WriteLine(responseString);
       }
   }
