using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAppConsumer.Models
{
   public class CarDataArray
   {
      [JsonPropertyName("data")]
      public Car[] Data { get; set; }
   }

   public class CarData
   {
      [JsonPropertyName("data")]
      public Car Data { get; set; }
   }

   public class Car
   {
      [JsonPropertyName("id")]
      public int Id { get; set; }

      [JsonPropertyName("title")]
      public string Title { get; set; }
      
      [JsonPropertyName("purchase")]
      public DateTime Purchase { get; set; }
      
      [JsonPropertyName("value")]
      public decimal Value { get; set; }

      [JsonPropertyName("active")]
      public bool Active { get; set; }
   }
}
