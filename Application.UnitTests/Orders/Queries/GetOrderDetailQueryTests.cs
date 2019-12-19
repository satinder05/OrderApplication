using System.Threading;
using System.Threading.Tasks;
using Application.Order.Queries;
using Application.UnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Orders.Queries
{
    public class GetOrderDetailQueryTests : QueryTestBase
    {
        [Fact]
        public async Task Handle_GivenValidGetOrderRequest_GetsOrderDetail()
        {
            //Arrange
            long testOrderId = 1;
            var request = new GetOrderDetailQuery { OrderId = testOrderId };
            var handler = new GetOrderDetailQuery.GetOrderDetailQueryHandler(_context, _mapper);
            long expectedCustomerId = 2;
            int expectedItemsCount = 1;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<OrderDetailVM>();
            result.OrderId.ShouldBe(testOrderId);
            result.CustomerId.ShouldBe(expectedCustomerId);
            result.OrderItems.Count.ShouldBe(expectedItemsCount);
        }

        [Fact]
        public async Task Handle_GivenInvalidValidGetOrderId_GetsNullResult()
        {
            //Arrange
            long testOrderId = 99;
            var request = new GetOrderDetailQuery { OrderId = testOrderId };
            var handler = new GetOrderDetailQuery.GetOrderDetailQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBe(null);

        }
    }
}
