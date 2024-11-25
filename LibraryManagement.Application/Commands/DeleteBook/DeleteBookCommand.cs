﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
