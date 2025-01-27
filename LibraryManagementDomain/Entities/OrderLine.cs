using System;

namespace LibraryManagement.Domain.Entities
{
    public class OrderLine
    {
        public Guid? Id { get; set; }
        public Guid BookId { get; set; } // FK
        public Book? Book { get; set; }
        public int Quantity { get; set; }
        public Order? Order { get; set; }
        public Guid OrderId { get; set; } // FK
    }
}
