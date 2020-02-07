using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Customers.Commands;
using Application.Customers.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCustomerCommand request)
        {
            var result = await new CreateCustomerCommand.CreateCustomerCommandHandler(_context).Handle(request, CancellationToken.None);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<CustomerDetailVm> Get(long id)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery { Id = id };
            CustomerDetailVm result = await new GetCustomerDetailQuery.GetCustomerDetailQueryHandler(_context, _mapper).Handle(query, CancellationToken.None);
            return result;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerCommand command)
        {
            await new UpdateCustomerCommand.UpdateCustomerCommandHandler(_context).Handle(command, CancellationToken.None);

            return NoContent();
        }


    }
}
