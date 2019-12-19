using Persistence;
using System;
using AutoMapper;
using Application.Common.Mappings;

namespace Application.UnitTests.Common
{
    public class QueryTestBase : IDisposable
    {
        protected readonly OrderTestContext _context;
        protected readonly IMapper _mapper;

        public QueryTestBase()
        {
            _context = OrderDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            OrderDbContextFactory.Destroy(_context);
        }
    }
}
