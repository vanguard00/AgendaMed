using Agenda.SharedKernel.Entities;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Entities
{
    public class Hospital : Entity
    {
        public Hospital(string name, List<Specialty> specialties)
        {
            Name = name;
            Specialties = specialties;
        }

        public string Name { get; private set; }
        public List<Specialty> Specialties { get; private set; }

        public void Update(string name, List<Specialty> specialties)
        {
            Name = name;
            Specialties = specialties;
        }
    }
}
