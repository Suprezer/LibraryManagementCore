using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderLineDTO> OrderLines { get; set; }
        //public int TotalBooks { get; set; }
    }
}
