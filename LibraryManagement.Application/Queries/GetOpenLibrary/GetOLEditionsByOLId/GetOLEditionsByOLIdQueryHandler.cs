using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.IService;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetOpenLibrary.GetOLEditionsByOLId
{
    public class GetOLEditionsByOLIdQueryHandler : IRequestHandler<GetOLEditionsByOLIdQuery, ICollection<EditionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IOpenLibraryEditionService _openLibraryEditionService;

        public GetOLEditionsByOLIdQueryHandler(IMapper mapper, IOpenLibraryEditionService openLibraryEditionService)
        {
            _mapper = mapper;
            _openLibraryEditionService = openLibraryEditionService;
        }

        public async Task<ICollection<EditionDTO>> Handle(GetOLEditionsByOLIdQuery request, CancellationToken cancellationToken)
        {
            List<EditionDTO> foundEditions = new List<EditionDTO>();

            if (request.searchCriteria.WorkOLId != null)
            {
                var response = await _openLibraryEditionService.GetAllEditionsByOLIdAsync(request.searchCriteria);

                if (response != null && response != null)
                {
                    foreach (var edition in response.entries)
                    {
                        var editionDTO = _mapper.Map<EditionDTO>(edition);
                        foundEditions.Add(editionDTO);
                    }
                }
            }

            return foundEditions;
        }
    }
}
