using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.Doctor
{
    public class UpdateDoctorCommand : ICommand
    {
        public Guid DoctorId { get; set; }
        public Guid SpecialtyId { get; set; }
        public string Name { get; set; }
        public string CRM { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
