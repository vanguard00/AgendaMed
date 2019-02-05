using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Account.Commands.Inputs
{
    public class UpdateUserStatusCommand : ICommand
    {
        public Guid UserId { get; set; }
        public bool Status { get; set; }
    }
}
