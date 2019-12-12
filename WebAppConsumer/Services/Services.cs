using Canducci.GraphQLQuery;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace WebAppConsumer.Services
{
   public abstract class Services
   {
      private HttpClient Client { get; set; }
      public Services(HttpClient client)
      {         
         Client = client;
         Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
      }
      public async Task<T> PostAsync<T>(TypeQL typeQL)
      {         
         StringContent content = new StringContent(typeQL, Encoding.UTF8, "application/json");
         HttpResponseMessage message = await Client.PostAsync(string.Empty, content);
         if (message.StatusCode == System.Net.HttpStatusCode.OK)
         {
            string json = await message.Content.ReadAsStringAsync();
            T data = Deserialize<T>(json);
            return data;
         }
         return default;
      }

      public T Deserialize<T>(string json)
      {
         JsonSerializerOptions options = new JsonSerializerOptions
         {
            IgnoreNullValues = true            
         };
         options.Converters.Add(TimeSpanConverter.Create());
         return JsonSerializer.Deserialize<T>(json, options);
      }
      
   }
   public class TimeSpanConverter : JsonConverter<TimeSpan?>
   {
      public static TimeSpanConverter Create() => new TimeSpanConverter();
      public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      {
         var str = reader.GetString();
         if (!string.IsNullOrEmpty(str))
         {
            if (TimeSpan.TryParse(str, out TimeSpan time))
            {
               return time;
            }
         }
         return null;
      }
      public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
      {
         if (value.HasValue)
         {
            writer.WriteStringValue(value?.ToString(@"hh\:mm\:ss"));
         }
         else
         {
            writer.WriteNullValue();
         }
      }
   }
}
