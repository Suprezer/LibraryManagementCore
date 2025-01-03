using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.GetOpenLibraryBooks
{
    // This model will only contain the properties that are required for searching books
    public class BookSearchCriteria
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
