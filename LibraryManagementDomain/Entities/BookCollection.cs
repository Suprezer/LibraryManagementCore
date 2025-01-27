using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class BookCollection
    {
        public int TotalBooks { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
