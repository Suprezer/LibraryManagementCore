using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagement.Application.Queries.ISBNDB.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ISBNDBController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ISBNDBController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance for sending queries.</param>
        public ISBNDBController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the HTTP POST request to get books based on the search criteria.
        /// </summary>
        /// <param name="searchCriteria">The criteria for searching books.</param>
        /// <returns>An IActionResult containing the search results.</returns>
        [HttpPost]
        public async Task<IActionResult> GetBooks([FromBody] BookSearchCriteria searchCriteria)
        {
            // Create a query object with the provided search criteria
            var query = new GetISBNDBBooksQuery { searchCriteria = searchCriteria };

            // Send the query using MediatR and await the result
            var result = await _mediator.Send(query);

            // Return the result as an HTTP 200 OK response
            return Ok(result);
        }
    }
}
