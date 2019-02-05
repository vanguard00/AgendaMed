using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.Hospital
{
    public class RemoveSpecialtyCommand : ICommand
    {
        public Guid HospitalId { get; set; }
        public Guid SpecialtylId { get; set; }
    }
}
