using Agenda.Domain.Management.Entities;
using Agenda.SharedKernel.Entities;
using System;

namespace Agenda.Domain.BookService.Entities
{
    public class Book : Entity
    {
        public Book(string user, Doctor doctor, DateTime bookTime, Exam exam)
        {
            User = user;
            Doctor = doctor;
            BookTime = bookTime;
            Exam = exam;
            Status = "Reservado";
        }

        public string User { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime BookTime { get; private set; }
        public Exam Exam { get; private set; }
        public string Status { get; private set; }

        public void Cancel()
        {
            Status = "Cancelado";
        }

        public void Finish()
        {
            Status = "Finalizado";
        }

        public void Update(string user, Doctor doctor, DateTime bookTime, Exam exam)
        {
            BookTime = bookTime;
        }
    }
}
