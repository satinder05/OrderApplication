using Persistence;

namespace Application.UnitTests.Common
{
    public class TestBase
    {
        protected readonly OrderTestContext _context;

        public TestBase()
        {
            _context = OrderDbContextFactory.Create();
        }

        public void Dispose()
        {
            OrderDbContextFactory.Destroy(_context);
        }
    }
}
