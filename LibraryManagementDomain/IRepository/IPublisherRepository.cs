using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.IRepository
{
    public interface IPublisherRepository
    {
        Task<Publisher> GetByIdAsync(Guid id);
        Task<Publisher> GetByNameAsync(string name);
        Task<bool> AddAsync(Publisher publisher);
    }
}
