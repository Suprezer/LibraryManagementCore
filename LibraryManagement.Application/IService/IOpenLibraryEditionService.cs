using LibraryManagement.Application.DTOs.OpenLibrary;
using LibraryManagement.Application.Queries.GetOpenLibrary;
using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.IService
{
    public interface IOpenLibraryEditionService
    {
        Task<OLEditionResponseDTO> GetAllEditionsByOLIdAsync(EditionSearchCriteria searchCriteria);
    }
}
