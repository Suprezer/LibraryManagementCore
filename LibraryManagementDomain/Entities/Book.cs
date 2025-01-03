using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Book
    {
        // The unique identifier for the book
        public Guid Id { get; set; }
        // The ISBN of the book (International Standard Book Number)
        public string ISBN { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public DateTime PublishedYear { get; set; }
        public string OrderStatus { get; set; }
        public int? Quantity { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public string Description { get; set; }
        // The unique identifier for the book from the Open Library API
        public string OLId { get; set; }

        public Book()
        {
            
        }
    }
}