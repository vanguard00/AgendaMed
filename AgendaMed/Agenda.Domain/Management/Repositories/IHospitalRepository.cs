using Agenda.Domain.Management.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Repositories
{
    public interface IHospitalRepository
    {
        void Save(Hospital hospital);
        void Update(Hospital hospital);
        void Delete(Guid id);
        List<Hospital> Hospitals();
        Hospital GetHospitalById(Guid id);
    }
}
