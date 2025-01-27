using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.IRepository
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(Guid id);
        Task<Author> GetByNameAsync(string name);
        Task<bool> AddAsync(Author author);
    }
}
