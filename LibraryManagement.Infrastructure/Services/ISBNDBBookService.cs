using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagement.Application.IService;
using System.Net;
using System.Text;
using System.Text.Json;

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
            var queryString = new StringBuilder();
            queryString.Append($"/books/{Uri.EscapeDataString(searchCriteria.Query)}?");

            if (searchCriteria.Page.HasValue)
            {
                queryString.Append($"page={searchCriteria.Page.Value}&");
            }

            if (searchCriteria.PageSize.HasValue)
            {
                queryString.Append($"pageSize={searchCriteria.PageSize.Value}&");
            }

            if (!string.IsNullOrEmpty(searchCriteria.Column) && searchCriteria.Column != "string")
            {
                queryString.Append($"column={searchCriteria.Column}&");
            }

            if (searchCriteria.YearOfPublication.HasValue && searchCriteria.YearOfPublication != 0)
            {
                queryString.Append($"year={searchCriteria.YearOfPublication.Value}&");
            }

            if (searchCriteria.Edition.HasValue && searchCriteria.Edition != 0)
            {
                queryString.Append($"edition={searchCriteria.Edition.Value}&");
            }

            if (!string.IsNullOrEmpty(searchCriteria.Language) && searchCriteria.Language != "string")
            {
                queryString.Append($"language={searchCriteria.Language}&");
            }

            // Removal of any trailing ampersands
            if (queryString[queryString.Length - 1] == '&')
            {
                queryString.Length--;
            }

            // Currently left out
            //queryString.Append($"&shouldMatchAll={searchCriteria.shouldMatchAll}");

            var response = await _httpClient.GetAsync(queryString.ToString());
            ISBNDBBookDTO searchResult;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                searchResult = JsonSerializer.Deserialize<ISBNDBBookDTO>(content);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                searchResult = new ISBNDBBookDTO
                {
                    total = 0,
                    books = new List<BookEntries>()
                };
            }
            else
            {
                throw new HttpRequestException("Failed to retrieve books from ISBNDB");
            }

            return searchResult;
        }
    }
}
