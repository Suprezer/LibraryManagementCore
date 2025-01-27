using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Author
    {
        public Guid? Id { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Author()
        {
            
        }
    }
}
