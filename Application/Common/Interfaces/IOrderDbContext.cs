using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerOrder> CustomerOrders { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
