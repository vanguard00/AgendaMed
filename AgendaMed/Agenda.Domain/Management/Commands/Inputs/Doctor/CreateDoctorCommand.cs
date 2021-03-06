﻿using Agenda.SharedKernel.Commands;
using System;

namespace Agenda.Domain.Management.Commands.Inputs.Doctor
{
    public class CreateDoctorCommand : ICommand
    {
        public Guid SpecialtyId { get; set; }
        public string Name { get; set; }
        public string CRM { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
