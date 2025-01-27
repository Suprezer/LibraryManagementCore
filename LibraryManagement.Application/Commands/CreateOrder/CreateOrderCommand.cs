using LibraryManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public OrderDTO Order { get; set; }
    }
}
