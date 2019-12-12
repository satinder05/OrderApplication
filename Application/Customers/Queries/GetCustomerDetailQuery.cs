using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Queries
{
    public class GetCustomerDetailQuery
    {
        public long Id { get; set; }

        public class GetCustomerDetailQueryHandler
        {
            private readonly IOrderDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomerDetailQueryHandler(IOrderDbContext orderContext, IMapper mapper)
            {
                _context = orderContext;
                _mapper = mapper;
            }
            public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Customers
                .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new Exception("Customer Not Found");
                }

                return _mapper.Map<CustomerDetailVm>(entity);
            }
        }
    }
}
