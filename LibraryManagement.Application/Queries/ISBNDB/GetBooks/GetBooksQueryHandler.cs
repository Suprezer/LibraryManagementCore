using AutoMapper;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagement.Application.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.ISBNDB.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetISBNDBBooksQuery, ISBNDBBookDTO>
    {
        private readonly IMapper _mapper;
        private readonly IISBNDBBookService _iSBNDBBookService;

        public GetBooksQueryHandler(IMapper mapper, IISBNDBBookService iSBNDBBookService)
        {
            _mapper = mapper;
            _iSBNDBBookService = iSBNDBBookService;
        }

        public Task<ISBNDBBookDTO> Handle(GetISBNDBBooksQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
