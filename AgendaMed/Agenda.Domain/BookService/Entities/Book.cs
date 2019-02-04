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

            DateValidate(bookTime);
            AddNotifications(user.Notifications);
            AddNotifications(doctor.Notifications);
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
            DateValidate(bookTime);
            BookTime = bookTime;
        }

        private void DateValidate(DateTime bookTime)
        {
            if (bookTime.DayOfWeek == DayOfWeek.Saturday || bookTime.DayOfWeek == DayOfWeek.Sunday)
                AddNotification("BookTime", "Só é possível agendar consultas de segunda a sexta.");
            if (bookTime.TimeOfDay > TimeSpan.Parse("18") && bookTime.TimeOfDay < TimeSpan.Parse("8"))
                AddNotification("BookTime", "Só é possível agendar consultas para o horario entre 8hr e 18hr.");
            if (bookTime.TimeOfDay >= TimeSpan.Parse("12") && bookTime.TimeOfDay <= TimeSpan.Parse("14"))
                AddNotification("BookTime", "Não é possível agendar consultas entre as 12hr e as 14hr.");
        }
    }
}
