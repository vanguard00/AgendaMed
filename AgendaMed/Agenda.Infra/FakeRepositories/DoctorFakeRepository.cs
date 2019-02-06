using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.Domain.Management.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.FakeRepositories
{
    public class DoctorFakeRepository : IDoctorRepository
    {
        public List<Doctor> doctors = new List<Doctor>();

        public DoctorFakeRepository(SpecialtyFakeRepository specialtyFakeRepository = null)
        {
            specialtyFakeRepository = specialtyFakeRepository ?? new SpecialtyFakeRepository();

            Document cpf = new Document("39258256069");
            Document cpf2 = new Document("96610116059");
            doctors = new List<Doctor>()
            {
                new Doctor("Usson", "151775266", cpf, DateTime.Parse("15/03/1976"), specialtyFakeRepository.specialties.FirstOrDefault()),
                new Doctor("Hadur", "241039964", cpf2, DateTime.Parse("01/04/1995"), specialtyFakeRepository.specialties[1])
            };
        }

        public void Delete(Guid id)
        {
            doctors.RemoveAll(x => x.Id == id);
        }

        public Doctor GetById(Guid id)
        {
            return doctors.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Doctor> GetDoctorsBySpecialty(Guid id)
        {
            return doctors.Where(x => x.Specialty.Id == id).ToList();
        }

        public void Save(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public void Update(Doctor doctor)
        {
            int index = doctors.IndexOf(doctor);
            doctors.RemoveAt(index);
            doctors.Insert(index, doctor);
        }
    }
}
