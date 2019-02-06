using Agenda.Domain.Management.Commands.Handlers;
using Agenda.Domain.Management.Commands.Inputs.Hospital;
using Agenda.Domain.Management.Commands.Results.Hospital;
using Agenda.Infra.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Agenda.Domain.Tests.Management.Commands
{
    [TestClass]
    [TestCategory("Hospital")]
    public class HospitalCommandHandlerTests
    {
        private readonly HospitalFakeRepository hospitalRepository;
        private readonly SpecialtyFakeRepository specialtyRepository;
        private readonly HospitalCommandHandler _handler;

        public HospitalCommandHandlerTests()
        {
            hospitalRepository = new HospitalFakeRepository();
            specialtyRepository = new SpecialtyFakeRepository();
            _handler = new HospitalCommandHandler(hospitalRepository, specialtyRepository);
        }

        [TestMethod]
        public void Should_Create_A_Valid_Hospital()
        {
            CreateHospitalCommand command = new CreateHospitalCommand()
            {
                Name = "Sirio Libanês"
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Update_A_Hospital()
        {
            UpdateHospitalCommand command = new UpdateHospitalCommand()
            {
                HospitalId = hospitalRepository.hospitals.FirstOrDefault().Id,
                Name = "Sirio Libanês"
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Add_A_Specialty_To_A_Hospital()
        {
            AddSpecialtyCommand command = new AddSpecialtyCommand()
            {
                HospitalId = hospitalRepository.hospitals.FirstOrDefault().Id,
                SpecialtylId = specialtyRepository.specialties[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Remove_A_Specialty_From_A_Hospital()
        {
            RemoveSpecialtyCommand command = new RemoveSpecialtyCommand()
            {
                HospitalId = hospitalRepository.hospitals.FirstOrDefault().Id,
                SpecialtylId = specialtyRepository.specialties[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Delete_A_Hospital()
        {
            DeleteHospitalCommand command = new DeleteHospitalCommand()
            {
                HospitalId = hospitalRepository.hospitals.FirstOrDefault().Id
            };
            var result = (DeleteHospitalCommandResult)_handler.Handler(command);
            Assert.IsTrue(result.Deleted);
        }

        [TestMethod]
        public void Should_Return_A_Hospital()
        {
            Assert.IsNotNull(_handler.GetById(hospitalRepository.hospitals.FirstOrDefault().Id));
        }

        [TestMethod]
        public void Should_Return_A_List_Of_All_Hospitals()
        {
            Assert.IsTrue(_handler.Hospitals().Count > 0);
        }

        [TestMethod]
        public void Should_Return_A_List_Of_Specialty_By_Hospitals()
        {
            Assert.IsTrue(_handler.GetSpecialtiesByHospital(hospitalRepository.hospitals.FirstOrDefault().Id).Count > 0);
        }
    }
}
