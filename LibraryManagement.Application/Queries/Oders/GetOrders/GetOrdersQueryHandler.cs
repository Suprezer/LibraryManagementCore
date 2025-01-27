using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Filters;
using LibraryManagement.Domain.Filters;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Oders.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ICollection<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<OrderFilter>(request.orderFilter);
            var orders = await _unitOfWork.Orders.GetFilteredOrdersAsync(filter);

            var orderDTOs = _mapper.Map<ICollection<OrderDTO>>(orders);

            return orderDTOs;
        }
    }
}
