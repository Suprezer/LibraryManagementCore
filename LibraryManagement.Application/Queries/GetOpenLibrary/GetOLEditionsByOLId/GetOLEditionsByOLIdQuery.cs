using LibraryManagement.Application.DTOs;
using LibraryManagementAPI.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.GetOpenLibrary.GetOLEditionsByOLId
{
    public class GetOLEditionsByOLIdQuery : IRequest<EditionCollectionDTO>
    {
        public EditionSearchCriteria searchCriteria { get; set; }
    }
}
