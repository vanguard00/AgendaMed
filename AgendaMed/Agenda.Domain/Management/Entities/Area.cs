using Agenda.SharedKernel.Entities;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Entities
{
    public class Area : Entity
    {
        public Area(string name, List<Specialty> specialty)
        {
            Name = name;
            Specialty = specialty;
        }

        public string Name { get; private set; }
        public List<Specialty> Specialty { get; private set; }

        public void Update(string name, List<Specialty> specialty)
        {
            Name = name;
            Specialty = specialty;
        }
    }
}
