using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid id);
        Task<Book> GetByISBNAsync(string isbn);
        Task<BookCollection> GetAllAsync(BookSearching criteria);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
    }
}
