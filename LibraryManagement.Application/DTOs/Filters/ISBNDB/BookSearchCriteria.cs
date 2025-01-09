using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs.Filters.ISBNDB
{
    public class BookSearchCriteria
    {
        public string query { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string column { get; set; }
        public int yearOfPublication { get; set; }
        public int edition { get; set; }
        // Examplpes would be  en for English, fr for French, etc.
        public string language { get; set; }
        // If set to 1, the API will return books where the title or author exactly contains all the words entered by the user.
        public int shouldMatchAll { get; set; }


    }
}
