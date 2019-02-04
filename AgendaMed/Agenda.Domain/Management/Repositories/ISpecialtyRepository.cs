using Agenda.Domain.Management.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Repositories
{
    public interface ISpecialtyRepository
    {
        void Save(Specialty specialty);
        void Update(Specialty specialty);
        void Delete(Guid id);
        List<Specialty> GetSpecialtiesByHospital(Guid id);
        Specialty GetById(Guid id);
    }
}
