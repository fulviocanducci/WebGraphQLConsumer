using Canducci.GraphQLQuery;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppConsumer.Models;

namespace WebAppConsumer.Services
{

   public class CarService : Services
   {
      public CarService(HttpClient client)
         : base(client)
      {
      }

      private async Task<Car> CreateOrUpdateAsync(Car car, string name)
      {
         using TypeQL typeQL = new TypeQL(
            new QueryType(name,
               "data",
               new Arguments(
                  new Argument("car", car)
               ),
               new Fields(
                  new Field("id"),
                  new Field("title"),
                  new Field("purchase"),
                  new Field("value"),
                  new Field("active")
               )
            )
         );
         var result = await PostAsync<CarData>(typeQL);
         return result.Data;
      }
      public async Task<Car> AddAsync(Car car)
      {
         return await CreateOrUpdateAsync(car, "car_add");
      }

      public async Task<Car> EditAsync(Car car)
      {
         return await CreateOrUpdateAsync(car, "car_edit");
      }

      public async Task<Car> FindAsync(int id)
      {
         using TypeQL typeQL = new TypeQL(
            new QueryType("car_find",
               "data",
               new Arguments(
                  new Argument("id", id)
               ),
               new Fields(
                  new Field("id"),
                  new Field("title"),
                  new Field("purchase"),
                  new Field("value"),
                  new Field("active")
               )
            )
         );
         var result = await PostAsync<CarData>(typeQL);
         return result.Data;
      }
      public async Task<IList<Car>> ToListAsync()
      {
         using TypeQL typeQL = new TypeQL(
            new QueryType("cars",
               "data",
               new Fields(
                  new Field("id"),
                  new Field("title"),
                  new Field("purchase"),
                  new Field("value"),
                  new Field("active")
               )
            )
         );
         var result = await PostAsync<CarDataArray>(typeQL);
         return result.Data;
      }
      public async Task<Car> RemoveAsync(int id)
      {
         using TypeQL typeQL = new TypeQL(
            new QueryType("car_delete",
               "data",
               new Arguments(
                  new Argument("id", id)
               ),
               new Fields(
                  new Field("operation"),
                  new Field("status"),
                  new Field("description")
               )
            )
         );
         var result = await PostAsync<CarData>(typeQL);
         return result.Data;
      }
   }
}
