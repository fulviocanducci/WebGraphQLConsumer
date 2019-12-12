using System.Text.Json.Serialization;

namespace WebAppConsumer.Models
{
   public class DeletedTypeData
   {
      [JsonPropertyName("data")]
      public DeletedType Data { get; set; }
   }
   public class DeletedType
   {
      [JsonPropertyName("data")]
      public ReturnType Deleted { get; set; }
   }
}
