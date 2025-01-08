using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.GetOpenLibrary
{
    // This model will only contain the properties that are required for searching books
    public class BookSearchCriteria
    {
        // The page number of search results, for pagination for the OpenLibrary API
        public int page { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
