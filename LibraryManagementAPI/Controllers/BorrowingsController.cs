using LibraryManagement.Application.Commands.BorrowBook;
using LibraryManagement.Application.Commands.Borrowing.BorrowBook;
using LibraryManagement.Application.Queries.Borrowing.GetAllBorrowings;
using LibraryManagement.Application.Queries.Borrowing.GetBorrowingsByUserId;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BorrowingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromQuery] Guid bookId, [FromQuery] Guid userId)
        {
            try
            {
                var command = new BorrowBookCommand
                {
                    BookId = bookId,
                    UserId = userId
                };

                var borrowingId = await _mediator.Send(command);
                return Ok(borrowingId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBorrowingsByUserId(Guid userId)
        {
            var query = new GetBorrowingsByUserIdQuery { UserId = userId };
            var borrowings = await _mediator.Send(query);

            return Ok(borrowings);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBorrowings()
        {
            var borrowings = await _mediator.Send(new GetAllBorrowingsQuery());

            return Ok(borrowings);
        }
    }
}
