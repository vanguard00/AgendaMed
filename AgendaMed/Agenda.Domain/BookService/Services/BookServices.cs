using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using Agenda.Domain.BookService.Entities;
using Agenda.Domain.BookService.Repositories;
using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.BookService.Services
{
    public class BookServices : Notifiable
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        public BookServices(IBookRepository bookRepository, IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public void Create(Guid userId, Guid doctorId, DateTime bookTime)
        {
            User user = _userRepository.GetById(userId);
            Doctor doctor = _doctorRepository.GetById(doctorId);
            Book book = new Book(user, doctor, bookTime);
            AddNotifications(book.Notifications);
            if (IsValid())
                return;
            _bookRepository.Save(book);
        }

        public void Update(Guid userId, Guid bookId, DateTime bookTime)
        {
            Book book = _bookRepository.GetById(bookId);
            if (!(book.User.Id == userId))
                AddNotification("User", "O usuário não tem permissão para alterar essa reserva.");
            book.Update(bookTime);
            AddNotifications(book.Notifications);
            if (IsValid())
                return;
            _bookRepository.Update(book);
        }

        public void Cancel(Guid userId, Guid bookId)
        {
            Book book = _bookRepository.GetById(bookId);
            if (!(book.User.Id == userId))
                AddNotification("User", "O usuário não tem permissão para alterar essa reserva.");
            book.Cancel();
            AddNotifications(book.Notifications);
            if (IsValid())
                return;
            _bookRepository.Cancel(book);
        }

        public void Finish(Guid userId, Guid bookId)
        {
            Book book = _bookRepository.GetById(bookId);
            if (!(book.User.Id == userId))
                AddNotification("User", "O usuário não tem permissão para alterar essa reserva.");
            book.Finish();
            AddNotifications(book.Notifications);
            if (IsValid())
                return;
            _bookRepository.Finish(book);
        }

        public Book GetById(Guid bookId)
        {
            return _bookRepository.GetById(bookId);
        }

        public List<Book> Books()
        {
            return _bookRepository.Books();
        }

        public List<Book> GetBooksByDate(DateTime date)
        {
            return _bookRepository.GetBooksByDate(date);
        }

        public List<Book> GetBooksByDoctor(Guid doctorId)
        {
            return _bookRepository.GetBooksByDoctor(doctorId);
        }

        public List<Book> GetBooksByUser(Guid userId)
        {
            return _bookRepository.GetBooksByUser(userId);
        }
    }
}
