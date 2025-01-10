using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.IService;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetOpenLibrary.GetOLBooks
{
    public class GetOLBooksQueryHandler : IRequestHandler<GetOLBooksQuery, ICollection<BookDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IOpenLibraryBookService _openLibraryBookService;

        public GetOLBooksQueryHandler(IMapper mapper, IOpenLibraryBookService openLibraryBookService)
        {
            _mapper = mapper;
            _openLibraryBookService = openLibraryBookService;
        }

        public async Task<ICollection<BookDTO>> Handle(GetOLBooksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private string RemoveKeyPrefix(string key)
        {
            return key?.Split('/').Last();
        }
    }
}
