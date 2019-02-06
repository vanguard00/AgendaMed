using Agenda.Domain.Management.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Repositories
{
    public interface IHospitalRepository
    {
        void Save(Hospital hospital);
        void Update(Hospital hospital);
        void UpdateSpecialty(Hospital hospital);
        void Delete(Guid id);
        List<Hospital> Hospitals();
        List<Specialty> GetSpecialtiesByHospital(Guid id);
        Hospital GetById(Guid id);
    }
}
