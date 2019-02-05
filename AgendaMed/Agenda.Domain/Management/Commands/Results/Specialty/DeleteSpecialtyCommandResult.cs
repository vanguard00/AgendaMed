using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Results.Specialty
{
    public class DeleteSpecialtyCommandResult : ICommandResult
    {
        public DeleteSpecialtyCommandResult()
        {

        }
        public DeleteSpecialtyCommandResult(Guid specialtyId, bool deleted)
        {
            SpecialtyId = specialtyId;
            Deleted = deleted;
        }

        public Guid SpecialtyId { get; set; }
        public bool Deleted { get; set; }
    }
}
