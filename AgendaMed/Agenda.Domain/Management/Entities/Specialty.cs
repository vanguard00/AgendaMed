using Agenda.SharedKernel.Entities;

namespace Agenda.Domain.Management.Entities
{
    public class Specialty : Entity
    {
        public Specialty(string name)
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
