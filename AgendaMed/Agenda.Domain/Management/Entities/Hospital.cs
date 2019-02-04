using Agenda.SharedKernel.Entities;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Entities
{
    public class Hospital : Entity
    {
        public Hospital(string name, List<Area> areas)
        {
            Name = name;
            Areas = areas;
        }

        public string Name { get; private set; }
        public List<Area> Areas { get; private set; }

        public void Update(string name, List<Area> areas)
        {
            Name = name;
            Areas = areas;
        }
    }
}
