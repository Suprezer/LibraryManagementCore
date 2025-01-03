using LibraryManagement.Application.DTOs.OpenLibrary;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;
using System.Text.Json;

namespace LibraryManagement.Infrastructure.Services
{
    public class OpenLibraryBookService : IOpenLibraryBookService
    {
        private readonly HttpClient _httpClient;

        public OpenLibraryBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OLBookResponseDTO> GetBooksByTitleAsync(string title)
        {
            title = title.Replace(" ", "+");

            // It uses the following API for searching books by title: https://openlibrary.org/dev/docs/api/search
            var response = await _httpClient.GetAsync($"https://openlibrary.org/search.json?title={title}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<OLBookResponseDTO>(content);

            return searchResult;
        }

        public async Task<OLBookResponseDTO> GetBooksByAuthorAsync(string author)
        {
            author = author.Replace(" ", "+");

            // It uses the following API for searching books by author: https://openlibrary.org/dev/docs/api/search
            var response = await _httpClient.GetAsync($"https://openlibrary.org/search.json?author={author}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<OLBookResponseDTO>(content);

            return searchResult;
        }
    }
}
