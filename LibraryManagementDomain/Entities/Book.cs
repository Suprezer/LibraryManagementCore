using LibraryManagement.Domain.Entities;
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
        public IEnumerable<Genre> Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Publisher Publisher { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
    }
}