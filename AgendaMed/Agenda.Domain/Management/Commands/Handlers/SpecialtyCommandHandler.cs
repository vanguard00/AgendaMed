using Agenda.Domain.Management.Commands.Inputs.SpecialtyInputs;
using Agenda.Domain.Management.Commands.Results.Doctor;
using Agenda.Domain.Management.Commands.Results.Specialty;
using Agenda.Domain.Management.Entities;
using Agenda.Domain.Management.Repositories;
using Agenda.SharedKernel.Commands;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Commands.Handlers
{
    public class SpecialtyCommandHandler :
        ICommandHandler<CreateSpecialtyCommand>,
        ICommandHandler<UpdateSpecialtyCommand>,
        ICommandHandler<DeleteSpecialtyCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyCommandHandler(IDoctorRepository doctorRepository, ISpecialtyRepository specialtyRepository)
        {
            _doctorRepository = doctorRepository;
            _specialtyRepository = specialtyRepository;
        }

        public ICommandResult Handler(CreateSpecialtyCommand command)
        {
            Specialty specialty = new Specialty(command.Name);
            if (!specialty.IsValid())
                return null;
            _specialtyRepository.Save(specialty);
            return new StandardSpecialtyCommandResult(specialty.Id, DateTime.Now);
        }

        public ICommandResult Handler(UpdateSpecialtyCommand command)
        {
            Specialty specialty = _specialtyRepository.GetById(command.SpecialtyId);
            specialty.Update(command.Name);
            if (!specialty.IsValid())
                return null;
            _specialtyRepository.Update(specialty);
            return new StandardSpecialtyCommandResult(specialty.Id, DateTime.Now);
        }

        public ICommandResult Handler(DeleteSpecialtyCommand command)
        {
            _specialtyRepository.Delete(command.SpecialtyId);
            return new DeleteSpecialtyCommandResult(command.SpecialtyId, true);
        }

        public Specialty GetById(Guid specialtyId)
        {
            return _specialtyRepository.GetById(specialtyId);
        }
    }
}
