using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Services
{
    public class HospitalServices
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public HospitalServices(IHospitalRepository hospitalRepository, ISpecialtyRepository specialtyRepository)
        {
            _hospitalRepository = hospitalRepository;
            _specialtyRepository = specialtyRepository;
        }

        public void Create(string name, List<Specialty> specialties)
        {
            Hospital hospital = new Hospital(name, specialties);
            if (!hospital.IsValid())
                return;
            _hospitalRepository.Save(hospital);
        }

        public void Update(Guid hospitalId, string name)
        {
            Hospital hospital = _hospitalRepository.GetById(hospitalId);
            hospital.Update(name);
            if (!hospital.IsValid())
                return;
            _hospitalRepository.Update(hospital);
        }

        public void AddSpecialty(Guid hospitalId, Guid specialtyId)
        {
            Specialty specialty = _specialtyRepository.GetById(specialtyId);
            Hospital hospital = _hospitalRepository.GetById(hospitalId);
            hospital.AddSpecialty(specialty);
            _hospitalRepository.UpdateSpecialty(hospital);
        }

        public void RemoveSpecialty(Guid hospitalId, Guid specialtyId)
        {
            Specialty specialty = _specialtyRepository.GetById(specialtyId);
            Hospital hospital = _hospitalRepository.GetById(hospitalId);
            hospital.RemoveSpecialty(specialty);
            _hospitalRepository.UpdateSpecialty(hospital);
        }

        public void Delete(Guid hospitalId)
        {
            _hospitalRepository.Delete(hospitalId);
        }

        public Hospital GetById(Guid hospitalId)
        {
            return _hospitalRepository.GetById(hospitalId);
        }

        public List<Hospital> Hospitals()
        {
            return _hospitalRepository.Hospitals();
        }
    }
}
