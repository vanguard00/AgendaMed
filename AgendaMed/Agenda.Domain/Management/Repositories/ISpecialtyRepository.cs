using Agenda.Domain.Management.Entities;
using System;

namespace Agenda.Domain.Management.Repositories
{
    public interface ISpecialtyRepository
    {
        void Save(Specialty specialty);
        void Update(Specialty specialty);
        void Delete(Guid id);
        Specialty GetById(Guid id);
    }
}
