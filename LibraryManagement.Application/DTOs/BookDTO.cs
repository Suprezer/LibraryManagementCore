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
        public string CoverImage { get; set; }
        public string TitleLong { get; set; }
        public string PublishedDate { get; set; }
        public string Publisher { get; set; }
        public string Synopsis { get; set; }
        public ICollection<string> Subjects { get; set; }
        public ICollection<string> Authors { get; set; }
        public string Isbn13 { get; set; }
        public string Isbn { get; set; }
        public string Isbn10 { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public string Edition { get; set; }

        // Could expand with dimension information

        public BookDTO()
        {
            
        }
    }
}
