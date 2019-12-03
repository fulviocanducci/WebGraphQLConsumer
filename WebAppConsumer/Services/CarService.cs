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
         //using TypeQL typeQL = new TypeQL(            
         //   new QueryType(name,
         //      new Fields(
         //         new Field("id"),
         //         new Field("title"),
         //         new Field("purchase"),
         //         new Field("value"),
         //         new Field("active")
         //      ),
         //      new Arguments(
         //         new Argument("input", car)
         //      )
         //   )
         //);
         //var result = await PostAsync<CarRoot>(typeQL);
         try
         {         
            TypeQL typeQL = new TypeQL(
               new Variables("getCars", 
                  new Variable("input", car, "car_input")
               ),
               new QueryType(name,
                  new Fields(
                     new Field("id"),
                     new Field("title"),
                     new Field("purchase"),
                     new Field("value"),
                     new Field("active")
                  ),
                  new Arguments(
                     new Argument(new Parameter("input"))
                  )
               )
            );
            var result = await PostAsync<CarRoot>(typeQL);
            return result.Data.Data;
         }
         catch (System.Exception ex)
         {
            throw ex;
         }
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
            new QueryType("car_find","data",
               new Fields(
                  new Field("id"),
                  new Field("title"),
                  new Field("purchase"),
                  new Field("value"),
                  new Field("active")
               ),
               new Arguments(
                  new Argument("id", id)
               )
            )
         );
         var result = await PostAsync<CarRoot>(typeQL);
         return result.Data.Data;
      }
      public async Task<IList<Car>> ToListAsync()
      {
         using TypeQL typeQL = new TypeQL(
            new QueryType("cars",
               new Fields(
                  new Field("id"),
                  new Field("title"),
                  new Field("purchase"),
                  new Field("value"),
                  new Field("active")
               )
            )
         );
         var result = await PostAsync<CarListRoot>(typeQL);
         return result.Data.Cars;
      }

      public async Task<Car> RemoveAsync(int id)
      {
         using TypeQL typeQL = new TypeQL(
            new QueryType("car_delete",
               new Fields(
                  new Field("operation"),
                  new Field("status"),
                  new Field("description")
               ),
               new Arguments(
                  new Argument("id", id)
               )
            )
         );
         var result = await PostAsync<Car>(typeQL);
         return result;
      }
   }
}
