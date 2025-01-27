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
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string TitleLong { get; set; }
        public string PublishedDate { get; set; }
        public Publisher? Publisher { get; set; }
        public Guid PublisherId { get; set; }
        public string? Synopsis { get; set; }
        public ICollection<Author> Authors { get; set; }
        public string? Isbn13 { get; set; }
        public string Isbn { get; set; }
        public string? Isbn10 { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public string? Edition { get; set; }
        public int Quantity { get; set; }

        public Book()
        {
            
        }
    }
}