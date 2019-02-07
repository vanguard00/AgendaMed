using Agenda.Domain.Account.Entities;
using Agenda.Domain.BookService.Enums;
using Agenda.Domain.Management.Entities;
using Agenda.SharedKernel.Entities;
using System;

namespace Agenda.Domain.BookService.Entities
{
    public class Book : Entity
    {
        public Book(User user, Doctor doctor, DateTime bookDate)
        {
            User = user;
            Doctor = doctor;
            BookDate = bookDate;
            Status = EStatus.Reserved;

            DateValidate(bookDate);
            AddNotifications(user.Notifications);
            AddNotifications(doctor.Notifications);
        }

        public User User { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime BookDate { get; private set; }
        public EStatus Status { get; private set; }

        public void Cancel()
        {
            Status = EStatus.Canceled;
        }

        public void Finish()
        {
            Status = EStatus.Finished;
        }

        public void Update(DateTime bookDate)
        {
            DateValidate(bookDate);
            BookDate = bookDate;
        }

        private void DateValidate(DateTime bookDate)
        {
            if (bookDate.DayOfWeek == DayOfWeek.Saturday || bookDate.DayOfWeek == DayOfWeek.Sunday)
                AddNotification("BookDate", "Só é possível agendar consultas de segunda a sexta.");
            if (bookDate.TimeOfDay > TimeSpan.Parse("18") && bookDate.TimeOfDay < TimeSpan.Parse("8"))
                AddNotification("BookDate", "Só é possível agendar consultas para o horario entre 8hr e 18hr.");
            if (bookDate.TimeOfDay >= TimeSpan.Parse("12") && bookDate.TimeOfDay <= TimeSpan.Parse("14"))
                AddNotification("BookDate", "Não é possível agendar consultas entre as 12hr e as 14hr.");
        }
    }
}
