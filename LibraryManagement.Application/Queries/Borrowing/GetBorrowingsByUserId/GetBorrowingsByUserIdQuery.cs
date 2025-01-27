using LibraryManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Borrowing.GetBorrowingsByUserId
{
    public class GetBorrowingsByUserIdQuery : IRequest<IEnumerable<BorrowingDTO>>
    {
        public Guid UserId { get; set; }
    }
}
