using LibraryManagement.Domain.Models;
using LibraryManagement.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPI.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public Author Author { get; set; }

        [Required]
        [StringLength(50)]
        public Genre Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
    }
}
