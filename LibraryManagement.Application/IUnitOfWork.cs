﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IBookRepository Books { get; }
        Task<int> CompleteAsync();
    }
}
