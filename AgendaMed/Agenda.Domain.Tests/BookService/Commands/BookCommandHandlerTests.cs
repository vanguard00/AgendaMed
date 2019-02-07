using Agenda.Domain.BookService.Commands.Handlers;
using Agenda.Domain.BookService.Commands.Inputs;
using Agenda.Infra.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Agenda.Domain.Tests.BookService.Commands
{
    [TestClass]
    [TestCategory("Hospital")]
    public class BookCommandHandlerTests
    {
        private readonly BookFakeRepository bookRepository;
        private readonly DoctorFakeRepository doctorRepository;
        private readonly UserFakeRepository userRepository;
        private readonly BookCommandHandler _handler;

        public BookCommandHandlerTests()
        {
            doctorRepository = new DoctorFakeRepository();
            userRepository = new UserFakeRepository();
            bookRepository = new BookFakeRepository(userRepository, doctorRepository);

            _handler = new BookCommandHandler(bookRepository, doctorRepository, userRepository);
        }

        [TestMethod]
        public void Should_Create_A_Valid_Book()
        {
            CreateBookCommand command = new CreateBookCommand()
            {
                DoctorId = doctorRepository.doctors[0].Id,
                UserId = userRepository.users[0].Id,
                BookDate = DateTime.Parse("17/06/2019 15:30:00")
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Update_A_Book()
        {
            UpdateBookCommand command = new UpdateBookCommand()
            {
                BookId = bookRepository.books[0].Id,
                UserId = userRepository.users[0].Id,
                BookDate = DateTime.Parse("17/06/2019 16:00:00")
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Cancel_A_Book()
        {
            CancelBookCommand command = new CancelBookCommand()
            {
                BookId = bookRepository.books[0].Id,
                UserId = userRepository.users[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Finish_A_Book()
        {
            FinishBookCommand command = new FinishBookCommand()
            {
                BookId = bookRepository.books[0].Id,
                UserId = userRepository.users[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Return_A_Book()
        {
            Assert.IsNotNull(_handler.GetById(bookRepository.books[0].Id));
        }

        [TestMethod]
        public void Should_Return_A_List_Of_All_Books()
        {
            Assert.IsTrue(_handler.Books().Count > 0);
        }

        [TestMethod]
        public void Should_Return_A_List_Of_All_Books_At_A_Date()
        {
            Assert.IsTrue(_handler.GetBooksByDate(DateTime.Parse("06/02/2019")).Count > 0);
        }

        [TestMethod]
        public void Should_Return_A_List_Of_All_Books_Of_A_Doctor()
        {
            Assert.IsTrue(_handler.GetBooksByDoctor(doctorRepository.doctors[0].Id).Count > 0);
        }

        [TestMethod]
        public void Should_Return_A_List_Of_All_Books_Of_A_User()
        {
            Assert.IsTrue(_handler.GetBooksByUser(userRepository.users[0].Id).Count > 0);
        }
    }
}
