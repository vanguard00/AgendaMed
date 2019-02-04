using Agenda.Domain.Management.ValueObjects;
using Agenda.SharedKernel.Entities;
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
        }
    }
}
