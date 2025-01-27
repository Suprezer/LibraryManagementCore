using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.IRepository;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly LibraryContext _context;

        public BorrowingRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BorrowingEnt>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Borrowings.Include(b => b.Book).Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<BorrowingEnt>> GetAllAsync()
        {
            return await _context.Borrowings.Include(b => b.Book).ToListAsync();
        }

        public async Task AddAsync(BorrowingEnt borrowing)
        {
            await _context.Borrowings.AddAsync(borrowing);
        }
    }
}
