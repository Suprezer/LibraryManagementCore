using System;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.IRepository;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryContext _context;

        public PublisherRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Publisher> GetByIdAsync(Guid id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task<Publisher> GetByNameAsync(string name)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<bool> AddAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

