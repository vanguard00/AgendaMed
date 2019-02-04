using Agenda.Domain.Management.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Repositories
{
    public interface IDoctorRepository
    {
        void Save(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Guid id);
        Doctor GetById(Guid id);
        List<Doctor> GetDoctorsBySpecialty(Guid id);
    }
}
