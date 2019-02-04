using Agenda.Domain.Management.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Specialty> specialties = new List<Specialty>()
            {
                new Specialty("Oncologia"),
                new Specialty("Cardiologia")
            };

            Hospital hospital = new Hospital("Dona Regina", specialties);
            Console.ReadKey();
        }
    }
}
