using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using Agenda.Domain.BookService.Commands.Inputs;
using Agenda.Domain.BookService.Commands.Results;
using Agenda.Domain.BookService.Entities;
using Agenda.Domain.BookService.Repositories;
using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.SharedKernel.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.BookService.Commands.Handlers
{
    public class BookCommandHandler : Notifiable,
        ICommandHandler<CreateBookCommand>,
        ICommandHandler<UpdateBookCommand>,
        ICommandHandler<CancelBookCommand>,
        ICommandHandler<FinishBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        public BookCommandHandler(IBookRepository bookRepository, IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public ICommandResult Handler(CreateBookCommand command)
        {
            User user = _userRepository.GetById(command.UserId);
            Doctor doctor = _doctorRepository.GetById(command.DoctorId);
            Book book = new Book(user, doctor, command.BookDate);
            AddNotifications(book.Notifications);
            if (!IsValid())
                return null;
            _bookRepository.Save(book);
            return new StandardBookCommandResult(book.Id, DateTime.Now);
        }

        public ICommandResult Handler(UpdateBookCommand command)
        {
            Book book = _bookRepository.GetById(command.BookId);
            if (!(book.User.Id == command.UserId))
                AddNotification("User", "O usuário não tem permissão para alterar essa reserva.");
            book.Update(command.BookDate);
            AddNotifications(book.Notifications);
            if (!IsValid())
                return null;
            _bookRepository.Update(book);
            return new StandardBookCommandResult(book.Id, DateTime.Now);
        }

        public ICommandResult Handler(CancelBookCommand command)
        {
            Book book = _bookRepository.GetById(command.BookId);
            if (!(book.User.Id == command.UserId))
                AddNotification("User", "O usuário não tem permissão para alterar essa reserva.");
            book.Cancel();
            AddNotifications(book.Notifications);
            if (!IsValid())
                return null;
            _bookRepository.UpdateStatus(book);
            return new StandardBookCommandResult();
        }

        public ICommandResult Handler(FinishBookCommand command)
        {
            Book book = _bookRepository.GetById(command.BookId);
            if (!(book.User.Id == command.UserId))
                AddNotification("User", "O usuário não tem permissão para alterar essa reserva.");
            book.Finish();
            AddNotifications(book.Notifications);
            if (!IsValid())
                return null;
            _bookRepository.UpdateStatus(book);
            return new StandardBookCommandResult();
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
