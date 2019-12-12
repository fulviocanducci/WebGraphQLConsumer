using System.Text.Json.Serialization;

namespace WebAppConsumer.Models
{
   public class ReturnType
   {
      [JsonPropertyName("status")]
      public bool Status { get; set; }

      [JsonPropertyName("description")]
      public string Description { get; set; }

      [JsonPropertyName("count")]
      public int Count { get; set; }
   }
}
