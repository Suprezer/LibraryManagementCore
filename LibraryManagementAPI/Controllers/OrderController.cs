using LibraryManagement.Application.Commands.CreateOrder;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Filters;
using LibraryManagement.Application.Queries.Oders.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new order with the specified details.
        /// </summary>
        /// <param name="order">The order details including order lines.</param>
        /// <returns>An IActionResult containing the result of the order creation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO order)
        {
            var result = await _mediator.Send(new CreateOrderCommand { Order = order });
            return Ok(result);
        }

        /// <summary>
        /// Retrieves orders with pagination and date range filtering.
        /// </summary>
        /// <param name="request">The pagination and date range parameters.</param>
        /// <returns>An IActionResult containing the filtered and paginated orders.</returns>
        [HttpPost("GetOrders")]
        public async Task<IActionResult> GetOrders([FromBody] OrderFilterDTO orderFilter)
        {
            var query = new GetOrdersQuery { orderFilter = orderFilter };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
