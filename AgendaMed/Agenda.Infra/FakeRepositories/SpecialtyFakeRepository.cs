using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.FakeRepositories
{
    public class SpecialtyFakeRepository : ISpecialtyRepository
    {
        public List<Specialty> specialties = new List<Specialty>();
        public SpecialtyFakeRepository()
        {
            Specialty specialty = new Specialty("Cardiologia");
            Specialty specialty2 = new Specialty("Oncologia");
            specialties.Add(specialty);
            specialties.Add(specialty2);
        }

        public void Delete(Guid id)
        {
            specialties.RemoveAll(x=>x.Id == id);
        }

        public Specialty GetById(Guid id)
        {
            return specialties.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Save(Specialty specialty)
        {
            specialties.Add(specialty);
        }

        public void Update(Specialty specialty)
        {
            int index = specialties.IndexOf(specialty);
            specialties.RemoveAt(index);
            specialties.Insert(index, specialty);
        }
    }
}
