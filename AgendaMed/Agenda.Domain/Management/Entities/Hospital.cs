using Agenda.SharedKernel.Entities;
using FluentValidator;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Entities
{
    public class Hospital : Entity
    {
        public Hospital(string name, List<Specialty> specialties)
        {
            Name = name;
            Specialties = specialties;

            new ValidationContract<Hospital>(this)
                .IsRequired(x => x.Name, "O nome do hospital deve ser informado.")

                .HasMaxLenght(x => x.Name, 100, "O nome do hospital deve ter no máximo 100 caracteres.");
        }

        public string Name { get; private set; }
        public List<Specialty> Specialties { get; private set; }

        public void Update(string name, List<Specialty> specialties)
        {
            Name = name;
            Specialties = specialties;

            new ValidationContract<Hospital>(this)
                .IsRequired(x => x.Name, "O nome do hospital deve ser informado.")

                .HasMaxLenght(x => x.Name, 100, "O nome do hospital deve ter no máximo 100 caracteres.");
        }
    }
}
