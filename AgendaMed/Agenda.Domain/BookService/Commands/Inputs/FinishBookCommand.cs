﻿using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.BookService.Commands.Inputs
{
    public class FinishBookCommand : ICommand
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
