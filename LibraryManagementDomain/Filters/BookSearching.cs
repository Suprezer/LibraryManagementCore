﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Filters
{
    public class BookSearching
    {
        public string Query { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
