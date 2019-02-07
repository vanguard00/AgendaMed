using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.BookService.Commands.Inputs
{
    public class CreateBookCommand : ICommand
    {
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime BookDate { get; set; }
    }
}
