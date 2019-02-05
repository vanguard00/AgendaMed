using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Results.Hospital
{
    public class StandardHospitalCommandResult : ICommandResult
    {
        public StandardHospitalCommandResult()
        {

        }
        public StandardHospitalCommandResult(Guid hospitalId, DateTime modifiedDate)
        {
            HospitalId = hospitalId;
            ModifiedDate = modifiedDate;
        }

        public Guid HospitalId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
