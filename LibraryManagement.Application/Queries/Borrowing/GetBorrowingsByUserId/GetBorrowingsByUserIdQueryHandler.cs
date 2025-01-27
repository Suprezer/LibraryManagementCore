using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Borrowing.GetBorrowingsByUserId
{
    public class GetBorrowingsByUserIdQueryHandler : IRequestHandler<GetBorrowingsByUserIdQuery, IEnumerable<BorrowingDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBorrowingsByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BorrowingDTO>> Handle(GetBorrowingsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var borrowings = await _unitOfWork.Borrowings.GetByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<BorrowingDTO>>(borrowings);
        }
    }
}
