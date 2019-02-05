using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.SpecialtyInputs
{
    public class DeleteSpecialtyCommand : ICommand
    {
        public Guid SpecialtyId { get; set; }
    }
}
