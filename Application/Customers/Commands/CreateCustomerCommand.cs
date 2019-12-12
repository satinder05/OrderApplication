using Application.Common.Interfaces;
using Domain.Entities;
using Application.Common.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public class CreateCustomerCommandHandler
        {
            private readonly IOrderDbContext _context;
            public CreateCustomerCommandHandler(IOrderDbContext orderContext)
            {
                _context = orderContext;
            }
            public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = new Customer
                {
                    Status = (short)DataStatus.Online,
                    Name = request.Name,
                    Email = request.Email
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(cancellationToken);
                return customer.Id;
            }
        }
    }
}
