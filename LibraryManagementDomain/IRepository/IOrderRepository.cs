using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetFilteredOrdersAsync(OrderFilter filter);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<bool> AddAsync(Order order);
        //Task UpdateAsync(Order order);
        //Task DeleteAsync(Guid id);
    }
}
