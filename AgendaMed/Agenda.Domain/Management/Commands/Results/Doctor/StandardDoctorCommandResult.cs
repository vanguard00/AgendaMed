using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Results.Doctor
{
    public class StandardDoctorCommandResult : ICommandResult
    {
        public StandardDoctorCommandResult()
        {

        }
        public StandardDoctorCommandResult(Guid doctorId, DateTime modifiedDate)
        {
            DoctorId = doctorId;
            ModifiedDate = modifiedDate;
        }

        public Guid DoctorId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
