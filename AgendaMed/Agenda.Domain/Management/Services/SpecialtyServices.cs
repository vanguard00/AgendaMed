using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Services
{
    public class SpecialtyServices
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyServices(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository)
        {
            _doctorRepository = doctorRepository;
            _specialtyRepository = specialtyRepository;
        }

        public void Create(string name)
        {
            Specialty specialty = new Specialty(name);
            if (!specialty.IsValid())
                return;
            _specialtyRepository.Save(specialty);
        }

        public void Update(Guid specialtyId, string name)
        {
            Specialty specialty = _specialtyRepository.GetById(specialtyId);
            specialty.Update(name);
            if (!specialty.IsValid())
                return;
            _specialtyRepository.Update(specialty);
        }

        public void Delete(Guid specialtyId)
        {
            _specialtyRepository.Delete(specialtyId);
        }

        public Specialty GetById(Guid specialtyId)
        {
            return _specialtyRepository.GetById(specialtyId);
        }

        public List<Specialty> GetSpecialtiesByHospital(Guid hospitalId)
        {
            return _specialtyRepository.GetSpecialtiesByHospital(hospitalId);
        }
    }
}
