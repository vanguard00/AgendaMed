using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Results.Doctor
{
    public class StandardSpecialtyCommandResult : ICommandResult
    {
        public StandardSpecialtyCommandResult()
        {

        }
        public StandardSpecialtyCommandResult(Guid specialtyId, DateTime modifiedDate)
        {
            SpecialtyId = specialtyId;
            ModifiedDate = modifiedDate;
        }

        public Guid SpecialtyId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
