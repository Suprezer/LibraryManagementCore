using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Borrowing.BorrowBook
{
    public class BorrowBookCommand : IRequest<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
