using Application.Customers.Commands;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Customers.Commands
{
    public class CreateCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateCustomer()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Name = "First Test", Email = "First.Test@test.com.au" };
            var handler = new CreateCustomerCommand.CreateCustomerCommandHandler(_context);
            long expectedResult = 4;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
