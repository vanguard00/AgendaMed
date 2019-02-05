using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.Hospital
{
    public class UpdateHospitalCommand : ICommand
    {
        public Guid HospitalId { get; set; }
        public string Name { get; set; }
    }
}
