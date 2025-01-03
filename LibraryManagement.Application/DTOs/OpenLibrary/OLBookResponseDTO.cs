using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs.OpenLibrary
{
    /// <summary>
    /// This model is generated purely to perfectly fit the API response from Open Library, to help me filter the information I receive.
    /// Created using https://json2csharp.com/
    /// </summary>
    public class OLBookResponseDTO
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public List<OLBookContentDTO> docs { get; set; }
        public int num_found { get; set; }
        public string q { get; set; }
        public object offset { get; set; }
    }
}
