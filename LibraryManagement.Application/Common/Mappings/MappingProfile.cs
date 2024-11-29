using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Domain.Models;
using LibraryManagementAPI.DTOs;

namespace LibraryManagement.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
