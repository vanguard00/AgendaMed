using Agenda.Domain.Management.Commands.Handlers;
using Agenda.Domain.Management.Commands.Inputs.Doctor;
using Agenda.Infra.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Tests.Management.Commands
{
    [TestClass]
    [TestCategory("Hospital")]
    public class DoctorCommandHandlerTests
    {
        private readonly DoctorFakeRepository doctorRepository;
        private readonly SpecialtyFakeRepository specialtyRepository;
        private readonly DoctorCommandHandler _handler;

        public DoctorCommandHandlerTests()
        {
            specialtyRepository = new SpecialtyFakeRepository();
            doctorRepository = new DoctorFakeRepository(specialtyRepository);

            _handler = new DoctorCommandHandler(doctorRepository, specialtyRepository);
        }

        [TestMethod]
        public void Should_Create_A_Valid_Doctor()
        {
            CreateDoctorCommand command = new CreateDoctorCommand()
            {
                Name = "Cacin",
                CRM = "330310744",
                CPF = "75317627060",
                DateOfBirth = DateTime.Parse("12/06/1986"),
                SpecialtyId = specialtyRepository.specialties[1].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Update_A_Doctor()
        {
            UpdateDoctorCommand command = new UpdateDoctorCommand()
            {
                DoctorId = doctorRepository.doctors[0].Id,
                Name = "Caciny",
                CPF = "75317627060",
                CRM = "330310744",
                DateOfBirth = DateTime.Parse("12/06/1986"),
                SpecialtyId = specialtyRepository.specialties[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Delete_A_Doctor()
        {
            DeleteDoctorCommand command = new DeleteDoctorCommand()
            {
                DoctorId = doctorRepository.doctors[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Return_A_Doctor()
        {
            Assert.IsNotNull(_handler.GetById(doctorRepository.doctors[0].Id));
        }

        [TestMethod]
        public void Should_Return_A_List_Of_Doctors_By_Specialty()
        {
            Assert.IsTrue(_handler.GetDoctorsBySpecialty(specialtyRepository.specialties[0].Id).Count > 0);
        }
    }
}
