using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.Doctor
{
    public class DeleteDoctorCommand : ICommand
    {
        public Guid DoctorId { get; set; }
    }
}
