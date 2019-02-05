using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.BookService.Commands.Results
{
    public class StandardBookCommandResult : ICommandResult
    {
        public StandardBookCommandResult()
        {

        }
        public StandardBookCommandResult(Guid bookId, DateTime modifiedDate)
        {
            BookId = bookId;
            ModifiedDate = modifiedDate;
        }

        public Guid BookId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
