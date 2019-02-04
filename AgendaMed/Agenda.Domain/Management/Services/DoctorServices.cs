using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.Domain.Management.ValueObjects;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Services
{
    public class DoctorServices
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public DoctorServices(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository)
        {
            _doctorRepository = doctorRepository;
            _specialtyRepository = specialtyRepository;
        }

        public void Create(string name, string crm, string cpf, DateTime dateOfBirth, Guid specialtyId)
        {
            Specialty specialty = _specialtyRepository.GetById(specialtyId);
            Document CPF = new Document(cpf);
            Doctor doctor = new Doctor(name, crm, CPF, dateOfBirth, specialty);
            if (!doctor.IsValid())
                return;
            _doctorRepository.Save(doctor);
        }

        public void Update(Guid doctorId, string name, string crm, string cpf, DateTime dateOfBirth, Guid specialtyId)
        {
            Specialty specialty = _specialtyRepository.GetById(specialtyId);
            Document CPF = new Document(cpf);
            Doctor doctor = _doctorRepository.GetById(doctorId);
            doctor.Update(name, crm, CPF, dateOfBirth, specialty);
            if (!doctor.IsValid())
                return;
            _doctorRepository.Update(doctor);
        }

        public void Delete(Guid doctorId)
        {
            _doctorRepository.Delete(doctorId);
        }

        public Doctor GetById(Guid doctorId)
        {
            return _doctorRepository.GetById(doctorId);
        }

        public List<Doctor> GetDoctorsBySpecialty(Guid specialtyId)
        {
            return _doctorRepository.GetDoctorsBySpecialty(specialtyId);
        }
    }
}
