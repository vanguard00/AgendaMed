using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.Infra.Infra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        IDB _db;
        public SpecialtyRepository(IDB db)
        {
            _db = db;
        }
        public void Delete(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "DELETE FROM Specialty WHERE ID=@ID";
                db.Execute(sql, new { @ID = id });
            }
        }

        public Specialty GetById(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Specialty WHERE ID=@ID";
                return db.QueryFirstOrDefault<Specialty>(sql, new { @ID = id });
            }
        }

        public void Save(Specialty specialty)
        {
            using (var db = _db.connection())
            {
                var sql = "INSERT INTO Specialty(ID, Name) VALUES (@Id, @Name)";
                db.Execute(sql, specialty);
            }
        }

        public List<Specialty> Specialties()
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Specialty";
                return db.Query<Specialty>(sql).ToList();
            }
        }

        public void Update(Specialty specialty)
        {
            using (var db = _db.connection())
            {
                var sql = "UPDATE Specialty SET Name = @Name";
                db.Execute(sql, specialty);
            }
        }
    }
}
