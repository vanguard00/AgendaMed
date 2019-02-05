using Agenda.Domain.Management.Commands.Inputs.Doctor;
using Agenda.Domain.Management.Commands.Results.Doctor;
using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.Domain.Management.ValueObjects;
using Agenda.SharedKernel.Commands;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Commands.Handlers
{
    public class DoctorCommandHandler :
        ICommandHandler<CreateDoctorCommand>,
        ICommandHandler<UpdateDoctorCommand>,
        ICommandHandler<DeleteDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public DoctorCommandHandler(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository)
        {
            _doctorRepository = doctorRepository;
            _specialtyRepository = specialtyRepository;
        }

        public ICommandResult Handler(CreateDoctorCommand command)
        {
            Specialty specialty = _specialtyRepository.GetById(command.SpecialtyId);
            Document cpf = new Document(command.CPF);
            Doctor doctor = new Doctor(command.Name, command.CRM, cpf, command.DateOfBirth, specialty);
            if (!doctor.IsValid())
                return null;
            _doctorRepository.Save(doctor);
            return new StandardDoctorCommandResult(doctor.Id, DateTime.Now);
        }

        public ICommandResult Handler(UpdateDoctorCommand command)
        {
            Specialty specialty = _specialtyRepository.GetById(command.SpecialtyId);
            Document cpf = new Document(command.CPF);
            Doctor doctor = _doctorRepository.GetById(command.DoctorId);
            doctor.Update(command.Name, command.CRM, cpf, command.DateOfBirth, specialty);
            if (!doctor.IsValid())
                return null;
            _doctorRepository.Update(doctor);
            return new StandardDoctorCommandResult(doctor.Id, DateTime.Now);
        }

        public ICommandResult Handler(DeleteDoctorCommand command)
        {
            _doctorRepository.Delete(command.DoctorId);
            return new DeleteDoctorCommandResult(command.DoctorId, true);
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
