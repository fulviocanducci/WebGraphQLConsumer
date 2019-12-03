using System;
using System.Text.Json.Serialization;


namespace WebAppConsumer.Models
{
   public class CarListRoot
   {
      [JsonPropertyName("data")]
      public Data Data { get; set; }
   }

   public class CarRoot
   {
      [JsonPropertyName("data")]
      public CarItem Data { get; set; }
   }

   public class CarItem
   {
      [JsonPropertyName("data")]
      public Car Data { get; set; }
   }

   public class Data
   {
      [JsonPropertyName("cars")]
      public Car[] Cars { get; set; }
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
