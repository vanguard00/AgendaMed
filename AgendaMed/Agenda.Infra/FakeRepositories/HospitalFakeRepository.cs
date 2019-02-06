using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.FakeRepositories
{
    public class HospitalFakeRepository : IHospitalRepository
    {
        public List<Hospital> hospitals = new List<Hospital>();
        public HospitalFakeRepository()
        {
            Hospital hospital = new Hospital("São Lucas");
            Hospital hospital2 = new Hospital("Dom Orione");
            hospitals.Add(hospital);
            hospitals.Add(hospital2);
        }

        public void Delete(Guid id)
        {
            hospitals.RemoveAll(x => x.Id == id);
        }

        public Hospital GetById(Guid id)
        {
            return hospitals.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Hospital> Hospitals()
        {
            return hospitals;
        }

        public List<Specialty> GetSpecialtiesByHospital(Guid id)
        {
            return hospitals.Where(x => x.Id == id).FirstOrDefault().Specialties;
        }

        public void Save(Hospital hospital)
        {
            hospitals.Add(hospital);
        }

        public void Update(Hospital hospital)
        {
            int index = hospitals.IndexOf(hospital);
            hospitals.RemoveAt(index);
            hospitals.Insert(index, hospital);
        }

        public void UpdateSpecialty(Hospital hospital)
        {
            int index = hospitals.IndexOf(hospital);
            hospitals.RemoveAt(index);
            hospitals.Insert(index, hospital);
        }
    }
}
