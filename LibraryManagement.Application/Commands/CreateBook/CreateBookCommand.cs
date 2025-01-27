using LibraryManagementAPI.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.CreateBook
{
    /// <summary>
    /// Command to create a new Book.
    /// </summary>
    public class CreateBookCommand : IRequest<Guid?>
    {
        public BookDTO Body { get; set; }
    }
}
