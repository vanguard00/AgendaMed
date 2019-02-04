using Agenda.Domain.Management.ValueObjects;
using Agenda.SharedKernel.Entities;
using FluentValidator;
using System;

namespace Agenda.Domain.Management.Entities
{
    public class Doctor : Entity
    {
        public Doctor(string name, string crm, Document cpf, DateTime dateOfBirth, Specialty specialty)
        {
            Name = name;
            CRM = crm;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
            Specialty = specialty;

            new ValidationContract<Doctor>(this)
                .IsRequired(x => x.Name, "O nome do médico deve ser informado.")
                .IsRequired(x => CRM, "O CRM do médico deve ser informado.")

                .HasMaxLenght(x => x.Name, 100, "O nome deve ter no máximo 100 caracteres.")
                .HasMaxLenght(x => x.Name, 20, "O nome deve ter no máximo 20 caracteres.");

            AddNotifications(specialty.Notifications);
            AddNotifications(cpf.Notifications);
        }

        public string Name { get; private set; }
        public string CRM { get; private set; }
        public Document CPF { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Specialty Specialty { get; private set; }
        
        public void Update(string name, string crm, Document cpf, DateTime dateOfBirth, Specialty specialty)
        {
            Name = name;
            CRM = crm;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
            Specialty = specialty;

            new ValidationContract<Doctor>(this)
                .IsRequired(x => x.Name, "O nome do médico deve ser informado.")
                .IsRequired(x => CRM, "O CRM do médico deve ser informado.")

                .HasMaxLenght(x => x.Name, 100, "O nome deve ter no máximo 100 caracteres.")
                .HasMaxLenght(x => x.Name, 20, "O nome deve ter no máximo 20 caracteres.");

            AddNotifications(specialty.Notifications);
            AddNotifications(cpf.Notifications);
        }
    }
}
