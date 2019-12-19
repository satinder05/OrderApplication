using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Items.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public ItemsController(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ItemListVM> GetAll()
        {
            var request = new GetItemsListQuery();
            var result = await new GetItemsListQuery.GetItemsListQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }
    }
}
