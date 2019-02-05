using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Results.Doctor
{
    public class DeleteDoctorCommandResult : ICommandResult
    {
        public DeleteDoctorCommandResult()
        {

        }
        public DeleteDoctorCommandResult(Guid doctorId, bool deleted)
        {
            DoctorId = doctorId;
            Deleted = deleted;
        }

        public Guid DoctorId { get; set; }
        public bool Deleted { get; set; }
    }
}
