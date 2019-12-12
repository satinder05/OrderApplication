using Persistence;
using System;
using Microsoft.EntityFrameworkCore;

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

            return context;
        }

        public static void Destroy(OrderTestContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
