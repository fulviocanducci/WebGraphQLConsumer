using System;
using System.ComponentModel.DataAnnotations;
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
      [Required]
      public string Title { get; set; }

      [JsonPropertyName("purchase")]
      [Required]
      [DataType(DataType.Date)]
      public DateTime Purchase { get; set; }

      [JsonPropertyName("value")]
      [Required]
      public decimal Value { get; set; }

      [JsonPropertyName("active")]
      [Required]
      public bool Active { get; set; }
   }
}
