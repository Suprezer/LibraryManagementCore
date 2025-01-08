using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;

namespace LibraryManagementAPI.DTOs
{
    /// <summary>
    /// A Book in my domain is what's considered a Work in OpenLibrary's domain.
    /// </summary>
    public class BookDTO
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public ICollection<AuthorDTO>? Authors { get; set; }
        public List<string> Languages { get; set; }
        public string CoverEditionKey { get; set; }
        public List<string> EditionKeys { get; set; }
        // This list of ISBNs will include ISBN-10 and ISBN-13 meaning it can have a larger count than EditionCount
        public List<string> ISBN { get; set; }
        public int MedianPageCount { get; set; }
        public int EditionCount { get; set; }
        public DateTime? FirstPublishedYear { get; set; }
        public string? OrderStatus { get; set; }
        public int? Quantity { get; set; }

        // Rating information
        public int? TotalRatingCount { get; set; }
        public int? RatingCount1 { get; set; }
        public int? RatingCount2 { get; set; }
        public int? RatingCount3 { get; set; }
        public int? RatingCount4 { get; set; }
        public int? RatingCount5 { get; set; }
        public double? RatingsAverage { get; set; }

        public string OLId { get; set; }

        public BookDTO()
        {
            
        }
    }
}
