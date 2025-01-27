using LibraryManagement.Domain.IRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IBookRepository Books { get; }
        IOrderRepository Orders { get; }
        IAuthorRepository Authors { get; }
        IPublisherRepository Publishers { get; }
        IBorrowingRepository Borrowings { get; }
        Task<int> CompleteAsync();
    }
}
