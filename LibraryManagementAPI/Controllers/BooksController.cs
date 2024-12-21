using LibraryManagement.Application.Commands.CreateBook;
using LibraryManagement.Application.Commands.DeleteBook;
using LibraryManagement.Application.Commands.UpdateBook;
using LibraryManagement.Application.Queries.GetAllBooks;
using LibraryManagement.Application.Queries.GetBookById;
using MediatR;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = id });

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }

        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);
            
            return Ok(bookId);
            //return CreatedAtAction(nameof(GetBookById), new { id = bookId }, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
        {
            //await _mediator.Send(command);
            //return Ok(command.Id);

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
