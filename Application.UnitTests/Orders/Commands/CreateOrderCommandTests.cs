using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Order.Commands;
using Application.UnitTests.Common;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Orders.Commands
{
    public class CreateOrderCommandTests : CommandTestBase
    {
        private CreateOrderCommand.CreateOrderCommandHandler _orderCommandHandler;

        public CreateOrderCommandTests()
        {
            _orderCommandHandler = new CreateOrderCommand.CreateOrderCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateOrder()
        {
            //Arrange
            long customerId = 3;
            List<long> orderItems = new List<long> { 1, 2 };
            var orderRequest = new CreateOrderCommand { CustomerId = customerId, ItemIds = orderItems };

            //Act
            var result = await _orderCommandHandler.Handle(orderRequest, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<long>();
        }

        [Fact]
        public async Task Handle_GivenInvalidCustomerId_ShouldThrowNotFoundException()
        {
            //Arrange
            long customerId = 99;
            List<long> orderItems = new List<long> { 1, 2 };
            var orderRequest = new CreateOrderCommand { CustomerId = customerId, ItemIds = orderItems };

            await Assert.ThrowsAsync<NotFoundException>(() => _orderCommandHandler.Handle(orderRequest, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenInvalidItem_ShouldThrowNotFoundException()
        {
            //Arrange
            long customerId = 1;
            List<long> orderItems = new List<long> { 99 };
            var orderRequest = new CreateOrderCommand { CustomerId = customerId, ItemIds = orderItems };

            await Assert.ThrowsAsync<NotFoundException>(() => _orderCommandHandler.Handle(orderRequest, CancellationToken.None));
        }

    }
}
