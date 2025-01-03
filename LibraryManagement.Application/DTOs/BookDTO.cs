using LibraryManagement.Application.DTOs;

namespace LibraryManagementAPI.DTOs
{
    public class BookDTO
    {
        // The unique identifier for the book
        public Guid Id { get; set; }
        // The ISBN of the book (International Standard Book Number)
        public string ISBN { get; set; }
        public string Title { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public DateTime PublishedYear { get; set; }
        public string OrderStatus { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid PublisherId { get; set; }
        public PublisherDTO Publisher { get; set; }
        public string Description { get; set; }
        // The unique identifier for the book from the Open Library API
        public string OLId { get; set; }

        public BookDTO()
        {
            
        }
    }
}
