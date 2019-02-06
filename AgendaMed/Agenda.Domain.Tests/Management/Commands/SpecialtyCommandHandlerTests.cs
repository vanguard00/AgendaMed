using Agenda.Domain.Management.Commands.Handlers;
using Agenda.Domain.Management.Commands.Inputs.SpecialtyInputs;
using Agenda.Infra.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agenda.Domain.Tests.Management.Commands
{
    [TestClass]
    [TestCategory("Hospital")]
    public class SpecialtyCommandHandlerTests
    {
        private readonly SpecialtyFakeRepository specialtyRepository;
        private readonly SpecialtyCommandHandler _handler;

        public SpecialtyCommandHandlerTests()
        {
            specialtyRepository = new SpecialtyFakeRepository();

            _handler = new SpecialtyCommandHandler(specialtyRepository);
        }

        [TestMethod]
        public void Should_Create_A_Valid_Specialty()
        {
            CreateSpecialtyCommand command = new CreateSpecialtyCommand()
            {
                Name = "Otorrinolaringologia"
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Update_A_Specialty()
        {
            UpdateSpecialtyCommand command = new UpdateSpecialtyCommand()
            {
                SpecialtyId = specialtyRepository.specialties[0].Id,
                Name = "Gastroenterologia"
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Delete_A_Specialty()
        {
            DeleteSpecialtyCommand command = new DeleteSpecialtyCommand()
            {
                SpecialtyId = specialtyRepository.specialties[0].Id
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Return_A_Specialty()
        {
            Assert.IsNotNull(_handler.GetById(specialtyRepository.specialties[0].Id));
        }

        [TestMethod]
        public void Should_Return_A_List_Of_Doctors_By_Specialty()
        {
            Assert.IsTrue(_handler.Specialties().Count > 0);
        }
    }
}
