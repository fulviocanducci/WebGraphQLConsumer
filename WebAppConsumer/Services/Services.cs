using Canducci.GraphQLQuery;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
            T data = JsonSerializer.Deserialize<T>(json);
            return data;
         }
         return default;
      }
   }
}
