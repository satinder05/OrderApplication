using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class UpdateCustomerCommand
    {
        public long Id { get; set; }
        public short Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public class UpdateCustomerCommandHandler
        {
            private readonly IOrderDbContext _orderContext;

            public UpdateCustomerCommandHandler(IOrderDbContext orderContext)
            {
                _orderContext = orderContext;
            }

            public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _orderContext.Customers
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Customer), request.Id);
                }

                entity.Name = request.Name;
                entity.Status = request.Status;
                entity.Email = request.Email;

                await _orderContext.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }

    }
}
