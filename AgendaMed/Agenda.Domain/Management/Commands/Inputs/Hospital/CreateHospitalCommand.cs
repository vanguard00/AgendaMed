using Agenda.Domain.Management.Entities;
using Agenda.SharedKernel.Commands;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Commands.Inputs.Hospital
{
    public class CreateHospitalCommand : ICommand
    {
        public string Name { get; set; }
        public List<Specialty> Specialties { get; set; }
    }
}
