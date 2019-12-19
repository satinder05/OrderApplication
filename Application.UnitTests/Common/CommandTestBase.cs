using Persistence;
using System;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly OrderTestContext _context;

        public CommandTestBase()
        {
            _context = OrderDbContextFactory.Create();
        }

        public void Dispose()
        {
            OrderDbContextFactory.Destroy(_context);
        }
    }
}
