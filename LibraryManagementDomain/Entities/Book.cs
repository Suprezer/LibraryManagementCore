using LibraryManagement.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public IEnumerable<Author> Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}