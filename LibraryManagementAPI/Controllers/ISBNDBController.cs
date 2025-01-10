using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagement.Application.Queries.ISBNDB.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ISBNDBController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ISBNDBController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetBooks([FromBody] BookSearchCriteria searchCriteria)
        {
            var query = new GetISBNDBBooksQuery { searchCriteria = searchCriteria };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
