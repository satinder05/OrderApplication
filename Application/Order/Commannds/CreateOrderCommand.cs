using Application.Common.Enums;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Order.Commands
{
    public class CreateOrderCommand
    {
        public long CustomerId { get; set; }
        public List<long> ItemIds { get; set; }

        public class CreateOrderCommandHandler
        {
            private readonly IOrderDbContext _context;
            public CreateOrderCommandHandler(IOrderDbContext orderContext)
            {
                _context = orderContext;
            }

            public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.FindAsync(request.CustomerId);
                if(customer == null)
                {
                    throw new NotFoundException(nameof(Customer), request.CustomerId);
                }

                var order = new CustomerOrder
                {
                    Status = (short)DataStatus.Online,
                    CustomerId = request.CustomerId,
                };
                _context.CustomerOrders.Add(order);
                await _context.SaveChangesAsync(cancellationToken);

                if (order.Id != 0)
                {
                    foreach (long itemId in request.ItemIds)
                    {
                        Item item = await _context.Items.FindAsync(itemId);
                        if (item == null)
                            throw new NotFoundException(nameof(Item), itemId);

                        var orderItem = new OrderItem
                        {
                            Status = (short)DataStatus.Online,
                            CustomerOrderId = order.Id,
                            ItemId = itemId,
                            Price = item.Price.GetValueOrDefault()
                        };
                        _context.OrderItems.Add(orderItem);
                    }
                }
                                
                await _context.SaveChangesAsync(cancellationToken);
                return order.Id;
            }
        }
    }
}
