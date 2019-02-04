using System;
using System.Collections.Generic;

namespace Agenda.Domain.Management.Entities
{
    public class Doctor
    {
        public Doctor(string name, string crm, DateTime dateOfBirth, List<Specialty> specialties)
        {
            Name = name;
            CRM = crm;
            DateOfBirth = dateOfBirth;
            Specialties = specialties;
        }

        public string Name { get; private set; }
        public string CRM { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public List<Specialty> Specialties { get; private set; }
        
        public void Update(string name, string crm, DateTime dateOfBirth, List<Specialty> specialties)
        {
            Name = name;
            CRM = crm;
            DateOfBirth = dateOfBirth;
            Specialties = specialties;
        }
    }
}
