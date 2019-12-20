using Application.Customers.Queries;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Customers.Queries
{
    public class GetCustomerDetailQueryTests : QueryTestBase
    {
        [Fact]
        public async Task Handle_GivenValidCustomerId_ShouldGetCustomer()
        {
            //Arrange
            long validCustomerId = 2;
            var query = new GetCustomerDetailQuery { Id = validCustomerId };
            var handler = new GetCustomerDetailQuery.GetCustomerDetailQueryHandler(_context, _mapper);

            //Act
            var vm = await handler.Handle(query, CancellationToken.None);

            Assert.IsType<CustomerDetailVm>(vm);
            Assert.Equal(validCustomerId, vm.CustomerId);
        }
    }
}
