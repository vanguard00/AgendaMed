using Agenda.SharedKernel.Entities;

namespace Agenda.Domain.Management.Entities
{
    public class Specialties : Entity
    {
        public Specialties(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        
        public void Update(string name)
        {
            Name = name;
        }
    }
}
