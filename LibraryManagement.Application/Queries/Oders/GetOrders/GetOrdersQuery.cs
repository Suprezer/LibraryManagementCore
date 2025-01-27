using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Filters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Oders.GetOrders
{
    public class GetOrdersQuery : IRequest<ICollection<OrderDTO>>
    {
        public OrderFilterDTO? orderFilter { get; set; }
    }
}
 