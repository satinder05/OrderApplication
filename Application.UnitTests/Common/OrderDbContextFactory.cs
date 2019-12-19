using Persistence;
using System;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.UnitTests.Common
{
    public class OrderDbContextFactory
    {
        public static OrderTestContext Create()
        {
            var options = new DbContextOptionsBuilder<OrderTestContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new OrderTestContext(options);
            context.Database.EnsureCreated();

            //Add some test data
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

            return context;
        }

        public static void Destroy(OrderTestContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
