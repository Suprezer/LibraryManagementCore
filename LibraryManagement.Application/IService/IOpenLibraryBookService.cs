using LibraryManagement.Application.DTOs.OpenLibrary;
using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.IService
{
    public interface IOpenLibraryBookService
    {
        Task<OLBookResponseDTO> GetBooksByTitleAsync(string title);
        Task<OLBookResponseDTO> GetBooksByAuthorAsync(string author);
    }
}
