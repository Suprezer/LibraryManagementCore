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
        public string Title { get; set; }
        public ICollection<string> Languages { get; set; }
        public ICollection<Author> Authors { get; set; }
        //public ICollection<Genre>? Genres { get; set; }
        public string CoverEditionKey { get; set; }
        public ICollection<string> EditionKeys { get; set; }
        // This list of ISBNs will include ISBN-10 and ISBN-13 meaning it can have a larger count than EditionCount
        public ICollection<string> ISBN { get; set; }
        public int MedianpageCount { get; set; }
        public int EditionCount { get; set; }
        public DateTime FirstPublishedYear { get; set; }
        public string? OrderStatus { get; set; }
        public int? Quantity { get; set; }
        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        // Rating information
        public int TotalRatingCount { get; set; }
        public int RatingCount1 { get; set; }
        public int RatingCount2 { get; set; }
        public int RatingCount3 { get; set; }
        public int RatingCount4 { get; set; }
        public int RatingCount5 { get; set; }

        public Book()
        {
            
        }
    }
}