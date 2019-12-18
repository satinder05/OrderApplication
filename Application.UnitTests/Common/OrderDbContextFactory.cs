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

            context.Customers.AddRange(new[] {
                new Customer { Name = "Test Customer1", Email = "Test.Customer1@test.com.au" },
                new Customer {  Name = "Test Customer2", Email = "Test.Customer2@test.com.au"},
                new Customer {  Name = "Test Customer3", Email = "Test.Customer3@test.com.au" },
            });

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
