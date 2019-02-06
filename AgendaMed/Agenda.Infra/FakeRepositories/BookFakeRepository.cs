using Agenda.Domain.BookService.Entities;
using Agenda.Domain.BookService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.FakeRepositories
{
    public class BookFakeRepository : IBookRepository
    {
        public List<Book> books = new List<Book>();
        public BookFakeRepository(UserFakeRepository userFakeRepository = null, DoctorFakeRepository doctorFakeRepository = null)
        {
            userFakeRepository = userFakeRepository ?? new UserFakeRepository();
            doctorFakeRepository = doctorFakeRepository ?? new DoctorFakeRepository();
            
            Book book = new Book(userFakeRepository.users.FirstOrDefault(), doctorFakeRepository.doctors.FirstOrDefault(), DateTime.Parse("06/02/2019 14:20:00"));
            Book book2 = new Book(userFakeRepository.users[1], doctorFakeRepository.doctors.FirstOrDefault(), DateTime.Parse("06/02/2019 15:00:00"));

            books.Add(book);
            books.Add(book2);
        }

        public List<Book> Books()
        {
            return books;
        }

        public void Cancel(Book book)
        {
            int index = books.IndexOf(book);
            books.RemoveAt(index);
            books.Insert(index, book);
        }

        public void Finish(Book book)
        {
            int index = books.IndexOf(book);
            books.RemoveAt(index);
            books.Insert(index, book);
        }

        public List<Book> GetBooksByDate(DateTime date)
        {
            return books.Where(x => x.BookTime.Date == date.Date).ToList();
        }

        public List<Book> GetBooksByDoctor(Guid id)
        {
            return books.Where(x => x.Doctor.Id == id).ToList();
        }

        public List<Book> GetBooksByUser(Guid id)
        {
            return books.Where(x => x.User.Id == id).ToList();
        }

        public Book GetById(Guid id)
        {
            return books.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Save(Book book)
        {
            books.Add(book);
        }

        public void Update(Book book)
        {
            int index = books.IndexOf(book);
            books.RemoveAt(index);
            books.Insert(index, book);
        }
    }
}
