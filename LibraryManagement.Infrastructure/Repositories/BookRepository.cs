using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Domain.Filters;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public async Task<BookCollection> GetAllAsync(BookSearching criteria)
        {
            var query = _context.Books
                .Include(b => b.Authors) // Include authors
                .AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Query))
            {
                query = query.Where(b => b.Title.Contains(criteria.Query));
            }

            var totalBooks = await query.CountAsync();

            if (criteria.Page.HasValue && criteria.PageSize.HasValue)
            {
                var skip = (criteria.Page.Value - 1) * criteria.PageSize.Value;
                query = query.Skip(skip).Take(criteria.PageSize.Value);
            }

            var books = await query.ToListAsync();

            return new BookCollection
            {
                TotalBooks = totalBooks,
                Books = books
            };
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.Books.Include(b => b.Authors).Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Book book)
        {
            //await _context.Books.Update(book);
        }

        public async Task<Book> GetByISBNAsync(string isbn)
        {
            // Just checking on the ISBN should be good
            return await _context.Books.FirstOrDefaultAsync(b => b.Isbn == isbn); //  || b.Isbn10 == isbn || b.Isbn13 == isbn
        }
    }
}

