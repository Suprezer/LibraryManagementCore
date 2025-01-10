using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs.Filters.ISBNDB
{
    public class BookSearchCriteria
    {
        public string Query { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? Column { get; set; }
        public int? YearOfPublication { get; set; }
        public int? Edition { get; set; }
        // Examplpes would be en for English, fr for French, etc.
        public string? Language { get; set; }
        // If set to 1, the API will return books where the title or author exactly contains all the words entered by the user.
        public int? ShouldMatchAll { get; set; }
    }
}
