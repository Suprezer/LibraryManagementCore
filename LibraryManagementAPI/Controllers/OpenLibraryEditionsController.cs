using LibraryManagement.Application.Queries.GetOpenLibrary.GetOLEditionsByOLId;
using LibraryManagementAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenLibraryEditionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpenLibraryEditionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetEditions([FromBody] GetOLEditionsByOLIdQuery query)
        {
            var editions = await _mediator.Send(query);
            return Ok(editions);
        }
    }
}
