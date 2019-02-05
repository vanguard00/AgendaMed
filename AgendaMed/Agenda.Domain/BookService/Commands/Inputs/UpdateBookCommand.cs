using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.BookService.Commands.Inputs
{
    public class UpdateBookCommand : ICommand
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BookTime { get; set; }
    }
}
