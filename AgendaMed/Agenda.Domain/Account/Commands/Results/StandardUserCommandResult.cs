using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Account.Commands.Results
{
    public class StandardUserCommandResult : ICommandResult
    {
        public StandardUserCommandResult()
        {

        }
        public StandardUserCommandResult(Guid userId, DateTime modifiedDate)
        {
            UserId = userId;
            ModifiedDate = modifiedDate;
        }

        public Guid UserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
