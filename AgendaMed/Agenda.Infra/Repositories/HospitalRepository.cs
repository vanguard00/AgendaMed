using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.Infra.Infra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly IDB _db;

        public HospitalRepository(IDB db)
        {
            _db = db;
        }

        public void Delete(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "DELETE FROM Hospital WHERE ID = @ID";
                db.Execute(sql, new { @ID = id });
            }
        }

        public Hospital GetById(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Hospital WHERE ID = @ID";
                return db.QueryFirstOrDefault<Hospital>(sql, new { @ID = id });
            }
        }

        public List<Specialty> GetSpecialtiesByHospital(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Specialty WHERE ID in (SELECT Specialty FROM HospitalSpecialty WHERE Hopistal = @Hospital)";
                return db.Query<Specialty>(sql, new { @Hospital = id}).ToList();
            }
        }

        public List<Hospital> Hospitals()
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Hospital";
                return db.Query<Hospital>(sql).ToList();
            }
        }

        public void Save(Hospital hospital)
        {
            using (var db = _db.connection())
            {
                var sql = "INSERT INTO Hospital(ID, Name) VALUES(@Id, @Name)";
                db.Execute(sql, hospital);
            }
        }

        public void Update(Hospital hospital)
        {
            using (var db = _db.connection())
            {
                var sql = "UPDATE Hospital SET Name = @Name";
                db.Execute(sql, hospital);
            }
        }

        public void AddSpecialty(Hospital hospital, Guid specialtyId)
        {
            using (var db = _db.connection())
            {
                var sql = "INSERT INTO HospitalSpecialty(Hospital, Specialty) VALUES(@Hospital, @Specialty)";
                db.Execute(sql, new { @Hospital = hospital.Id, @Specialty = specialtyId});
            }
        }

        public void RemoveSpecialty(Hospital hospital, Guid specialtyId)
        {
            using (var db = _db.connection())
            {
                var sql = "DELETE FROM HospitalSpecialty WHERE Hospital = @Hospital AND Specialty = @Specialty)";
                db.Execute(sql, new { @Hospital = hospital.Id, @Specialty = specialtyId });
            }
        }
    }
}
