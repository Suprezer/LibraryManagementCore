using LibraryManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Borrowing.GetAllBorrowings
{
    public class GetAllBorrowingsQueryHandler : IRequestHandler<GetAllBorrowingsQuery, List<BorrowingDTO>>
    {
        public Task<List<BorrowingDTO>> Handle(GetAllBorrowingsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
