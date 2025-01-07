using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Edition
    {
        // The ISBN of the book (International Standard Book Number)
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string EditionKey { get; set; }
        public DateTime PublishedYear { get; set; }
        public int NumberOfpages { get; set; }
    }
}
