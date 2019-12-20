using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Application.Items.Queries;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Items.Queries
{
    public class GetItemsListQueryTests : QueryTestBase
    {
        [Fact]
        public async Task GetItemsList()
        {
            //Arrange
            var request = new GetItemsListQuery();
            var handler =  new GetItemsListQuery.GetItemsListQueryHandler(_context, _mapper);
            int expectedItemsCount = 3;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ItemListVM>();
            result.Items.Count.ShouldBe(expectedItemsCount);
        }
    }
}
