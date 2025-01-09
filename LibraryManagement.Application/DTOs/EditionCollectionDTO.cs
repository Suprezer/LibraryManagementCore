using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class EditionCollectionDTO
    {
        public int totalEditions { get; set; }
        public ICollection<EditionDTO> Editions { get; set; }
    }
}
