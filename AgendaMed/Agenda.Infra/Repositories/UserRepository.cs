using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using Agenda.Infra.Infra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDB _db;

        public UserRepository(IDB db)
        {
            _db = db;
        }

        public User GetById(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM User WHERE ID = @ID";
                return db.QueryFirstOrDefault<User>(sql, param: new { @ID = id });
            }
        }

        public void Save(User user)
        {
            using (var db = _db.connection())
            {
                var sql = "INSERT INTO User(ID, Username, Password, Name) VALUES(@Id, @Username, @Password, @Name)";
                db.Execute(sql, user);
            }
        }

        public void Update(User user)
        {
            using (var db = _db.connection())
            {
                var sql = "UPDATE User SET Username = @Username, Name = @Name WHERE ID = @ID";
                db.Execute(sql, user);
            }
        }

        public List<User> Users()
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM User";
                return db.Query<User>(sql).ToList();
            }
        }
    }
}
