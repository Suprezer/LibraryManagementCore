using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.IService;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetOpenLibrary.GetOLEditionsByOLId
{
    public class GetOLEditionsByOLIdQueryHandler : IRequestHandler<GetOLEditionsByOLIdQuery, EditionCollectionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IOpenLibraryEditionService _openLibraryEditionService;

        public GetOLEditionsByOLIdQueryHandler(IMapper mapper, IOpenLibraryEditionService openLibraryEditionService)
        {
            _mapper = mapper;
            _openLibraryEditionService = openLibraryEditionService;
        }

        public async Task<EditionCollectionDTO> Handle(GetOLEditionsByOLIdQuery request, CancellationToken cancellationToken)
        {
            if (request.searchCriteria.WorkOLId != null)
            {
                var response = await _openLibraryEditionService.GetAllEditionsByOLIdAsync(request.searchCriteria);

                if (response != null)
                {
                    var editionCollectionDTO = _mapper.Map<EditionCollectionDTO>(response);

                    // Manually process the keys to remove unwanted parts
                    foreach (var edition in editionCollectionDTO.Editions)
                    {
                        edition.OLId = RemoveKeyPrefix(edition.OLId);
                        edition.AuthorKey = RemoveKeyPrefix(edition.AuthorKey);
                        edition.Language = RemoveKeyPrefix(edition.Language);
                        edition.BookId = RemoveKeyPrefix(edition.BookId);
                    }

                    return editionCollectionDTO;
                }
            }

            return new EditionCollectionDTO { totalEditions = 0, Editions = new List<EditionDTO>() };
        }

        private string RemoveKeyPrefix(string key)
        {
            return key?.Split('/').Last();
        }
    }
}
