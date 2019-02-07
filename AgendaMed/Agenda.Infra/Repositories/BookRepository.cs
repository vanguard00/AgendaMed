using Agenda.Domain.BookService.Entities;
using Agenda.Domain.BookService.Repositories;
using Agenda.Infra.Infra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDB _db;
        public BookRepository(IDB db)
        {
            _db = db;
        }

        public List<Book> Books()
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Book";
                return db.Query<Book>(sql).ToList();
            }
        }

        public void UpdateStatus(Book book)
        {
            using (var db = _db.connection())
            {
                var sql = "UPDATE Book SET Status = @Status WHERE ID = @ID";
                db.Execute(sql, new
                {
                    @ID = book.Id,
                    @Status = book.Status
                });
            }
        }

        public List<Book> GetBooksByDate(DateTime date)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Book WHERE CAST(BookDate AS date) = @Date";
                return db.Query<Book>(sql, new { @Date = date.Date}).ToList();
            }
        }

        public List<Book> GetBooksByDoctor(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Book WHERE Doctor = @Doctor";
                return db.Query<Book>(sql, new { @Doctor = id }).ToList();
            }
        }

        public List<Book> GetBooksByUser(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Book WHERE User = @User";
                return db.Query<Book>(sql, new { @User = id }).ToList();
            }
        }

        public Book GetById(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Book WHERE ID = @ID";
                return db.QueryFirstOrDefault<Book>(sql, new { ID = id });
            }
        }

        public void Save(Book book)
        {
            using (var db = _db.connection())
            {
                var sql = "INSERT INTO Book(ID, Doctor, User, BookDate) VALUES (@ID, @Doctor, @User, @BookDate)";
                db.Execute(sql, new
                {
                    @ID = book.Id,
                    @Doctor = book.Doctor.Id,
                    @User = book.User.Id,
                    @BookDate = book.BookDate,
                });
            }
        }

        public void Update(Book book)
        {
            using (var db = _db.connection())
            {
                var sql = "UPDATE Book SET BookDate = @BookDate WHERE ID = @ID";
                db.Execute(sql, new
                {
                    @ID = book.Id,
                    @BookDate = book.BookDate
                });
            }
        }
    }
}
