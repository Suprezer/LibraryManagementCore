using LibraryManagement.Application.Commands.CreateBook;
using LibraryManagement.Application.Commands.DeleteBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);
            
            return Ok(bookId);
            //return CreatedAtAction(nameof(GetBookById), new { id = bookId }, command);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(DeleteBookCommand command)
        {
            await _mediator.Send(command);

            return Ok(command.Id);
        }
    }
}
