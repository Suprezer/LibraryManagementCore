using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class BookCollectionDTO
    {
        public int TotalBooks { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
