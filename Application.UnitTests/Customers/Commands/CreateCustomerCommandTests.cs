using Application.Customers.Commands;
using Application.UnitTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTests.Customers.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests : TestBase
    {
        [TestMethod]
        public async Task Handle_GivenValidRequest_ShouldCreateCustomer()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Name = "First Test", Email = "First.Test@test.com.au" };
            var handler = new CreateCustomerCommand.CreateCustomerCommandHandler(_context);
            int expectedResult = 1;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
        
    }
}
