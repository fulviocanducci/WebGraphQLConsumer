using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAppConsumer.Models
{
   public class ReturnType
   {
      [JsonPropertyName("status")]
      public bool Status { get; set; }
      
      [JsonPropertyName("description")]
      public string Description { get; set; }

      [JsonPropertyName("operation")]
      public string Operation { get; protected set; }
   }
}
