using LibraryManagement.Domain.IRepository;
using LibraryManagementAPI.DTOs;

namespace LibraryManagement.Infrastructure.Services
{
    public class OpenLibraryBookService : IOpenLibraryBookService
    {
        private readonly HttpClient _httpClient;

        public OpenLibraryBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<BookDTO> GetBooksByAuthorAsync(string author)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> GetBooksByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}
