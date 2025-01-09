using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class EditionDTO
    {
        public Guid Id { get; set; }
        public string AuthorKey { get; set; }
        public string OLId { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }
        public string Title { get; set; }
        public string? ISBN10 { get; set; }
        public string? ISBN13 { get; set; }
        public string Publisher { get; set; }
        public string? Desciption { get; set; }
        public string? PublishDate { get; set; }
        public string? BookId { get; set; }
    }
}
