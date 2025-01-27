using System;
using System.Collections.Generic;

namespace LibraryManagement.Domain.Entities
{
    public class Order
    {
        public Guid? Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
