using LibraryManagement.Application.Queries.GetOpenLibraryBooks.GetOLBooks;
using LibraryManagementAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenLibraryBooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OpenLibraryBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IEnumerable<BookDTO>> GetBooks([FromBody] GetOLBooksQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
