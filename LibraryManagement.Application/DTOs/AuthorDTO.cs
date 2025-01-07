using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;

namespace LibraryManagement.Application.DTOs
{
    public class AuthorDTO
    {
        public Guid? Id { get; set; }
        public string AuthorKey { get; set; }
        public string AuthorName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }

        public ICollection<BookDTO>? Books { get; set; } = new List<BookDTO>();

        public AuthorDTO()
        {
            
        }
    }
}
