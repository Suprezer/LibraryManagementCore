using LibraryManagementAPI.DTOs;
using System;

namespace LibraryManagement.Domain.Entities
{
    public class OrderLineDTO
    {
        public Guid? Id { get; set; }
        public BookDTO Book { get; set; }
        public int Quantity { get; set; }
    }
}
