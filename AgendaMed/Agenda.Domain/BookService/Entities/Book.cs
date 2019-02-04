using Agenda.Domain.Account.Entities;
using Agenda.Domain.BookService.Enums;
using Agenda.Domain.Management.Entities;
using Agenda.SharedKernel.Entities;
using System;

namespace Agenda.Domain.BookService.Entities
{
    public class Book : Entity
    {
        public Book(User user, Doctor doctor, DateTime bookTime)
        {
            User = user;
            Doctor = doctor;
            BookTime = bookTime;
            Status = EStatus.Reserved;
        }

        public User User { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime BookTime { get; private set; }
        public EStatus Status { get; private set; }

        public void Cancel()
        {
            Status = EStatus.Canceled;
        }

        public void Finish()
        {
            Status = EStatus.Finished;
        }

        public void Update(DateTime bookTime)
        {
            BookTime = bookTime;
        }
    }
}
