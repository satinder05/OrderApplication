using Application.Common.Interfaces;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Queries
{
    public class GetOrderDetailQuery
    {
        public long OrderId { get; set; }

        public class GetOrderDetailQueryHandler
        {
            private readonly IOrderDbContext _context;
            private readonly IMapper _mapper;

            public GetOrderDetailQueryHandler(IOrderDbContext orderContext, IMapper mapper)
            {
                _context = orderContext;
                _mapper = mapper;
            }

            public async Task<OrderDetailVM> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.CustomerOrders
                                            .Where(c => c.Id == request.OrderId)
                                            .ProjectTo<OrderDetailVM>(_mapper.ConfigurationProvider)
                                            .SingleOrDefaultAsync(cancellationToken);
                
                return vm;
            }
        }
    }
}
