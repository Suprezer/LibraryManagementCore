using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.IRepository
{
    public interface IBorrowingRepository
    {
        Task<IEnumerable<BorrowingEnt>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<BorrowingEnt>> GetAllAsync();
        Task AddAsync(BorrowingEnt borrowing);
    }
}
