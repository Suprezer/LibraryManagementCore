using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagement.Application.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Services
{
    public class ISBNDBBookService : IISBNDBBookService
    {
        private readonly HttpClient _httpClient;

        public ISBNDBBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ISBNDBBookDTO> GetBooksAsync(BookSearchCriteria searchCriteria)
        {
            // TODO: FIX
            var response = await _httpClient.GetAsync($"book/{searchCriteria.query}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<ISBNDBBookDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return books;
        }
    }
}
