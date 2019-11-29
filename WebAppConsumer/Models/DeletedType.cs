using System.Text.Json.Serialization;

namespace WebAppConsumer.Models
{
   public class DeletedTypeData
   {
      [JsonPropertyName("data")]
      public DeletedType Data { get; set; }
   }
   public class DeletedType : ReturnType
   {

      public DeletedType()
      {
         Operation = "Delete";
      }
   }
}
