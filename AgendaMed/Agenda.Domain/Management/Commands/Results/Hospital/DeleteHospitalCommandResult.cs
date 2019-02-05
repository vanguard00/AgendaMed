using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Results.Hospital
{
    public class DeleteHospitalCommandResult : ICommandResult
    {
        public DeleteHospitalCommandResult()
        {

        }
        public DeleteHospitalCommandResult(Guid hospitalId, bool deleted)
        {
            HospitalId = hospitalId;
            Deleted = deleted;
        }

        public Guid HospitalId { get; set; }
        public bool Deleted { get; set; }
    }
}
