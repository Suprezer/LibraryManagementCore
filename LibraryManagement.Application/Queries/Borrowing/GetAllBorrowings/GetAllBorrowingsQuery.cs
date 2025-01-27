using LibraryManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Borrowing.GetAllBorrowings
{
    public class GetAllBorrowingsQuery : IRequest<List<BorrowingDTO>>
    {
    }
}
