using LibraryManagement.Application.DTOs.Filters;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Filters;
using LibraryManagement.Domain.IRepository;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing orders in the library system.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public OrderRepository(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets an author by their name.
        /// </summary>
        /// <param name="authorName">The name of the author.</param>
        /// <returns>The author if found; otherwise, null.</returns>
        public async Task<Author> GetAuthorByNameAsync(string authorName)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorName == authorName);
        }


        // Adds a new order to the database.
        public async Task<bool> AddAsync(Order order)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Dictionaries to store processed authors, publishers, and books
                    var processedAuthors = new Dictionary<string, Author>();
                    var processedPublishers = new Dictionary<string, Publisher>();
                    var processedBooks = new Dictionary<string, Book>();

                    foreach (var orderLine in order.OrderLines)
                    {
                        if (orderLine.Book != null)
                        {
                            // Check if the book already exists in the processedBooks dictionary
                            if (processedBooks.TryGetValue(orderLine.Book.Isbn, out var existingBook))
                            {
                                // If the book exists, update its quantity
                                existingBook.Quantity += orderLine.Quantity;
                                orderLine.Book = existingBook;
                            }
                            else
                            {
                                // If the book does not exist, check the database
                                existingBook = await GetBookByIsbnAsync(orderLine.Book.Isbn);
                                if (existingBook != null)
                                {
                                    // If the book exists in the database, update its quantity
                                    existingBook.Quantity += orderLine.Quantity;
                                    orderLine.Book = existingBook;
                                    processedBooks[orderLine.Book.Isbn] = existingBook;
                                }
                                else
                                {
                                    // If the book does not exist in the database, set the quantity for the new book
                                    orderLine.Book.Quantity = orderLine.Quantity;

                                    // Process authors for the new book
                                    for (int i = 0; i < orderLine.Book.Authors.Count; i++)
                                    {
                                        var author = orderLine.Book.Authors.ElementAt(i);
                                        if (processedAuthors.TryGetValue(author.AuthorName, out var existingAuthor))
                                        {
                                            // If the author exists, replace the new author with the existing one
                                            orderLine.Book.Authors.Remove(author);
                                            orderLine.Book.Authors.Add(existingAuthor);
                                        }
                                        else
                                        {
                                            // If the author does not exist, check the database
                                            existingAuthor = await GetAuthorByNameAsync(author.AuthorName);
                                            if (existingAuthor != null)
                                            {
                                                // If the author exists in the database, replace the new author with the existing one
                                                orderLine.Book.Authors.Remove(author);
                                                orderLine.Book.Authors.Add(existingAuthor);
                                                processedAuthors[author.AuthorName] = existingAuthor;
                                            }
                                            else
                                            {
                                                // If the author does not exist in the database, add the new author to the context
                                                _context.Authors.Add(author);
                                                processedAuthors[author.AuthorName] = author;
                                            }
                                        }
                                    }

                                    // Process publisher for the new book
                                    if (orderLine.Book.Publisher != null)
                                    {
                                        if (processedPublishers.TryGetValue(orderLine.Book.Publisher.Name, out var existingPublisher))
                                        {
                                            // If the publisher exists, replace the new publisher with the existing one
                                            orderLine.Book.Publisher = existingPublisher;
                                        }
                                        else
                                        {
                                            // If the publisher does not exist, check the database
                                            existingPublisher = await GetPublisherByNameAsync(orderLine.Book.Publisher.Name);
                                            if (existingPublisher != null)
                                            {
                                                // If the publisher exists in the database, replace the new publisher with the existing one
                                                orderLine.Book.Publisher = existingPublisher;
                                                processedPublishers[orderLine.Book.Publisher.Name] = existingPublisher;
                                            }
                                            else
                                            {
                                                // If the publisher does not exist in the database, add the new publisher to the context
                                                _context.Publishers.Add(orderLine.Book.Publisher);
                                                processedPublishers[orderLine.Book.Publisher.Name] = orderLine.Book.Publisher;
                                            }
                                        }
                                    }

                                    // Add the new book to the context
                                    _context.Books.Add(orderLine.Book);
                                    processedBooks[orderLine.Book.Isbn] = orderLine.Book;
                                }
                            }
                        }
                    }

                    // Add the order to the context
                    await _context.Orders.AddAsync(order);
                    // Save changes to the database
                    var result = await _context.SaveChangesAsync() > 0;
                    // Commit the transaction
                    await transaction.CommitAsync();
                    return result;
                }
                catch (DbUpdateException)
                {
                    // Rollback the transaction in case of an error
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets a book by its ISBN.
        /// </summary>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <returns>The book if found; otherwise, null.</returns>
        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Isbn == isbn);
        }

        /// <summary>
        /// Gets a publisher by their name.
        /// </summary>
        /// <param name="publisherName">The name of the publisher.</param>
        /// <returns>The publisher if found; otherwise, null.</returns>
        public async Task<Publisher> GetPublisherByNameAsync(string publisherName)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Name == publisherName);
        }

        /// <summary>
        /// Gets all orders from the database.
        /// </summary>
        /// <returns>A collection of orders.</returns>
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Book)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetFilteredOrdersAsync(OrderFilter filter)
        {
            var query = _context.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Book)
                .AsQueryable();

            if (filter.StartDate != default)
            {
                query = query.Where(o => o.OrderDate >= filter.StartDate);
            }

            if (filter.EndDate != default)
            {
                query = query.Where(o => o.OrderDate <= filter.EndDate);
            }

            return await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
        }
    }
}
