using Agenda.Domain.Management.Commands.Inputs.Hospital;
using Agenda.Domain.Management.Commands.Results.Hospital;
using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.SharedKernel.Commands;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Commands.Handlers
{
    public class HospitalCommandHandler :
        ICommandHandler<CreateHospitalCommand>,
        ICommandHandler<UpdateHospitalCommand>,
        ICommandHandler<AddSpecialtyCommand>,
        ICommandHandler<RemoveSpecialtyCommand>,
        ICommandHandler<DeleteHospitalCommand>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public HospitalCommandHandler(IHospitalRepository hospitalRepository, ISpecialtyRepository specialtyRepository)
        {
            _hospitalRepository = hospitalRepository;
            _specialtyRepository = specialtyRepository;
        }

        public ICommandResult Handler(CreateHospitalCommand command)
        {
            Hospital hospital = new Hospital(command.Name, command.Specialties);
            if (!hospital.IsValid())
                return null;
            _hospitalRepository.Save(hospital);
            return new StandardHospitalCommandResult(hospital.Id, DateTime.Now);
        }

        public ICommandResult Handler(UpdateHospitalCommand command)
        {
            Hospital hospital = _hospitalRepository.GetById(command.HospitalId);
            hospital.Update(command.Name);
            if (!hospital.IsValid())
                return null;
            _hospitalRepository.Update(hospital);
            return new StandardHospitalCommandResult(hospital.Id, DateTime.Now);
        }

        public ICommandResult Handler(AddSpecialtyCommand command)
        {
            Specialty specialty = _specialtyRepository.GetById(command.SpecialtylId);
            Hospital hospital = _hospitalRepository.GetById(command.HospitalId);
            hospital.AddSpecialty(specialty);
            _hospitalRepository.UpdateSpecialty(hospital);
            return new StandardHospitalCommandResult(hospital.Id, DateTime.Now);
        }

        public ICommandResult Handler(RemoveSpecialtyCommand command)
        {
            Specialty specialty = _specialtyRepository.GetById(command.SpecialtylId);
            Hospital hospital = _hospitalRepository.GetById(command.HospitalId);
            hospital.RemoveSpecialty(specialty);
            _hospitalRepository.UpdateSpecialty(hospital);
            return new StandardHospitalCommandResult(hospital.Id, DateTime.Now);
        }

        public ICommandResult Handler(DeleteHospitalCommand command)
        {
            _hospitalRepository.Delete(command.HospitalId);
            return new DeleteHospitalCommandResult(command.HospitalId, true);
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
