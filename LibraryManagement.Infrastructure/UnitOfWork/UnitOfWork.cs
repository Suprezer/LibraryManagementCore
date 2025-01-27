using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.IRepository;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        private BookRepository _bookRepository;
        private OrderRepository _orderRepository;
        private AuthorRepository _authorRepository;
        private PublisherRepository _publisherRepository;
        private BorrowingRepository _borrowingRepository;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
        }

        public IBookRepository Books => _bookRepository ??= new BookRepository(_context);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);
        public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);
        public IPublisherRepository Publishers => _publisherRepository ??= new PublisherRepository(_context);
        public IBorrowingRepository Borrowings => _borrowingRepository ??= new BorrowingRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
