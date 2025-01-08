using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.GetOpenLibrary
{
    public class EditionSearchCriteria
    {
        public int OffSet { get; set; } = 0;
        public string WorkOLId { get; set; }
    }
}
