using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllBooks
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDTO>>
    {
        
    }
}
