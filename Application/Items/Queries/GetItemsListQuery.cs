using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items.Queries
{
    public class GetItemsListQuery
    {
        public class GetItemsListQueryHandler
        {
            private readonly IOrderDbContext _context;
            private readonly IMapper _mapper;

            public GetItemsListQueryHandler(IOrderDbContext orderContext, IMapper mapper)
            {
                _context = orderContext;
                _mapper = mapper;
            }

            public async Task<ItemListVM> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
            {
                var items = await _context.Items
                    .ProjectTo<ItemDetailVM>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var vm = new ItemListVM
                {
                    Items = items
                };

                return vm;
            }
        }
    }
}
