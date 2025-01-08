using LibraryManagement.Application.DTOs.OpenLibrary;
using LibraryManagement.Application.IService;
using LibraryManagement.Application.Queries.GetOpenLibrary;
using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Services
{
    public class OpenLibraryEditionService : IOpenLibraryEditionService
    {
        private readonly HttpClient _httpClient;

        public OpenLibraryEditionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OLEditionResponseDTO> GetAllEditionsByOLIdAsync(EditionSearchCriteria searchCriteria)
        {
            var response = await _httpClient.GetAsync($"https://openlibrary.org{searchCriteria.WorkOLId}/editions.json?offset={searchCriteria.OffSet}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<OLEditionResponseDTO>(content);

            return searchResult;
        }
    }
}
