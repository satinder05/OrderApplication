using Application.Common.Exceptions;
using Application.Customers.Commands;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Customers.Commands
{
    public class UpdateCustomerCommandTests : TestBase
    {
        private UpdateCustomerCommand.UpdateCustomerCommandHandler _commandHandler;

        public UpdateCustomerCommandTests()
            : base()
        {
            _commandHandler = new UpdateCustomerCommand.UpdateCustomerCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundExceptionAsync()
        {
            long InvalidId = 999;
            var command = new UpdateCustomerCommand { Id = InvalidId, Email = "Test@test.com.au", Name = "Test Customer", Status = 1 };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(command, CancellationToken.None));
        }
    }
}
