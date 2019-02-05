using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.Hospital
{
    public class DeleteHospitalCommand : ICommand
    {
        public Guid HospitalId { get; set; }
    }
}
