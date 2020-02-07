using Domain.Entities;
using Newtonsoft.Json;
using Persistence;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Common
{
    public class Utilities
    {
        public static void PopulateTestData(OrderTestContext context)
        {
            //Customers
            context.Customers.AddRange(new[] {
                new Customer { Name = "Test Customer1", Email = "Test.Customer1@test.com.au" },
                new Customer {  Name = "Test Customer2", Email = "Test.Customer2@test.com.au"},
                new Customer {  Name = "Test Customer3", Email = "Test.Customer3@test.com.au" },
            });
            //Items
            context.Items.AddRange(new[]
            {
                new Item { Name = "Test Item1", Price = 10, Status = 1 },
                new Item { Name = "Test Item2", Price = 20, Status = 1 },
                new Item { Name = "Test Item3", Price = 30, Status = 1 },
            });
            //Order
            context.CustomerOrders.Add(new CustomerOrder { CustomerId = 2, Status = 1 });
            context.OrderItems.Add(new OrderItem { CustomerOrderId = 1, Status = 1, ItemId = 3, Price = 30 });

            context.SaveChanges();
        }

        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
    }
}
