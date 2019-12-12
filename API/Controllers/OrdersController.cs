using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Order.Commands;
using Application.Order.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateOrder([FromBody]CreateOrderCommand request)
        {
            var result = await new CreateOrderCommand.CreateOrderCommandHandler(_context).Handle(request, CancellationToken.None);
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<OrderDetailVM> GetOrder(long orderId)
        {
            var request = new GetOrderDetailQuery { OrderId = orderId };
            var result = await new GetOrderDetailQuery.GetOrderDetailQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }


    }
}
