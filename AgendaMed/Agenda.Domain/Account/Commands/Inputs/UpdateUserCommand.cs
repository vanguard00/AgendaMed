using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Account.Commands.Inputs
{
    public class UpdateUserCommand : ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
