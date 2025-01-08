using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs.OpenLibrary
{
    public class OLEditionResponseDTO
    {
        public Links links { get; set; }
        public int size { get; set; }
        public List<Entry> entries { get; set; }
    }
}
