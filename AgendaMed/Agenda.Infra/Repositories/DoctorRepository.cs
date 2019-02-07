using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.Infra.Infra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDB _db;
        public DoctorRepository(IDB db)
        {
            _db = db;
        }

        public void Delete(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "DELETE FROM Doctor WHERE ID = @ID";
                db.Execute(sql, new { @ID = id });
            }
        }

        public Doctor GetById(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Doctor WHERE ID = @ID";
                return db.QueryFirstOrDefault<Doctor>(sql, new { @ID = id });
            }
        }

        public List<Doctor> GetDoctorsBySpecialty(Guid id)
        {
            using (var db = _db.connection())
            {
                var sql = "SELECT * FROM Doctor";
                return db.Query<Doctor>(sql).ToList();
            }
        }

        public void Save(Doctor doctor)
        {
            using (var db = _db.connection())
            {
                var sql = "INSERT INTO Doctor(ID, Name, CRM, CPF, DateOfBirth, Specialty) VALUES (@ID, @Name, @CRM, @CPF, @DateOfBirth, @Specialty)";
                db.Execute(sql, new
                {
                    @ID = doctor.Id,
                    @Name = doctor.Name,
                    @CRM = doctor.CRM,
                    @CPF = doctor.CPF,
                    @DateOfBirth = doctor.DateOfBirth,
                    @Specialty = doctor.Specialty.Id
                });
            }
        }

        public void Update(Doctor doctor)
        {
            using (var db = _db.connection())
            {
                var sql = "UPDATE Doctor SET Name = @Name, CRM = @CRM, CPF = @CPF, DateOfBirth = @DateOfBirth, Specialty = @Specialty WHERE ID = @ID";
                db.Execute(sql, new
                {
                    @ID = doctor.Id,
                    @Name = doctor.Name,
                    @CRM = doctor.CRM,
                    @CPF = doctor.CPF,
                    @DateOfBirth = doctor.DateOfBirth,
                    @Specialty = doctor.Specialty.Id
                });
            }
        }
    }
}
