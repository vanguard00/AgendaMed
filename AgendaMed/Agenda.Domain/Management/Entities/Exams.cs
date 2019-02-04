using Agenda.SharedKernel.Entities;

namespace Agenda.Domain.Management.Entities
{
    public class Exams : Entity
    {
        public Exams(string name, decimal price, Specialty specialty)
        {
            Name = name;
            Price = price;
            Specialty = specialty;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Specialty Specialty { get; private set; }

        public void Update(string name, decimal price, Specialty specialty)
        {
            Name = name;
            Price = price;
            Specialty = specialty;
        }
    }
}
