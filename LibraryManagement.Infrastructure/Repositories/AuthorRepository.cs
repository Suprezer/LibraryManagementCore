using System;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.IRepository;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> GetByNameAsync(string name)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorName == name);
        }

        public async Task<bool> AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

