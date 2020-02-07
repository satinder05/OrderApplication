using API.IntegrationTests.Common;
using Application.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.Controllers.Customers
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateCustomerCommand
            {
                Name = "Adam Parrish",
                Email = "Test@Test.com.au"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync("/api/customers", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
