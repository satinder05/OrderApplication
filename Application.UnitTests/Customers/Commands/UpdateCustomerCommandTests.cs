using Application.Common.Exceptions;
using Application.Customers.Commands;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Customers.Commands
{
    public class UpdateCustomerCommandTests : CommandTestBase
    {
        private UpdateCustomerCommand.UpdateCustomerCommandHandler _commandHandler;

        public UpdateCustomerCommandTests()
            : base()
        {
            _commandHandler = new UpdateCustomerCommand.UpdateCustomerCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_GivenInvalidCustomerId_ThrowsNotFoundExceptionAsync()
        {
            long invalidCustomerId = 999;
            var command = new UpdateCustomerCommand { CustomerId = invalidCustomerId, Email = "Test@test.com.au", Name = "Test Customer", Status = 1 };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidCustomerIdAndRequest_ShouldUpdateCustomer()
        {
            long validCustomerId = 2;
            string newEmail = "NewEmail@test.com.au";
            string newName = "NewName";
            var command = new UpdateCustomerCommand { CustomerId = validCustomerId, Email = newEmail, Name = newName, Status = 1 };

            var updatedCustomer = await _commandHandler.Handle(command, CancellationToken.None);

            Assert.Equal(newEmail, updatedCustomer.Email);
            Assert.Equal(newName, updatedCustomer.Name);
        }
    }
}
