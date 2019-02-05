using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.SpecialtyInputs
{
    public class UpdateSpecialtyCommand : ICommand
    {
        public Guid SpecialtyId { get; set; }
        public string Name { get; set; }
    }
}
