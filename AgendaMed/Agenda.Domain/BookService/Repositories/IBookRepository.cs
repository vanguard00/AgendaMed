using Agenda.Domain.BookService.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.BookService.Repositories
{
    public interface IBookRepository
    {
        void Save(Book book);
        void Update(Book book);
        void UpdateStatus(Book book);
        Book GetById(Guid id);
        List<Book> Books();
        List<Book> GetBooksByDate(DateTime date);
        List<Book> GetBooksByDoctor(Guid id);
        List<Book> GetBooksByUser(Guid id);
    }
}
