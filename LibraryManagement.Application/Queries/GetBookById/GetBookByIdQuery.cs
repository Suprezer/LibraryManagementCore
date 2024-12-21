using LibraryManagementAPI.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public Guid Id { get; set; }
    }
}
