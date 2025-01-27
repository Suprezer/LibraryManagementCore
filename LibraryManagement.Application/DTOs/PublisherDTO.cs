using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class PublisherDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public ICollection<BookDTO>? Books { get; set; } = new List<BookDTO>();

        public PublisherDTO()
        {
            
        }
    }
}
