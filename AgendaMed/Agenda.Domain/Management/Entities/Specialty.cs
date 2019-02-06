using Agenda.SharedKernel.Entities;
using FluentValidator;

namespace Agenda.Domain.Management.Entities
{
    public class Specialty : Entity
    {
        public Specialty(string name)
        {
            Name = name;
            new ValidationContract<Specialty>(this)
                .IsRequired(x => x.Name, "O nome da especialidade deve ser informado.")
                .HasMaxLenght(x => x.Name, 100, "O nome deve ter no máximo 100 caracteres.");
        }

        public string Name { get; private set; }
        
        public void Update(string name)
        {
            Name = name;
            new ValidationContract<Specialty>(this)
                .IsRequired(x => x.Name, "O nome da especialidade deve ser informado.")
                .HasMaxLenght(x => x.Name, 100, "O nome deve ter no máximo 100 caracteres.");
        }
    }
}
