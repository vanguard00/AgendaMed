﻿using Agenda.Domain.Account.Commands.Handlers;
using Agenda.Domain.Account.Commands.Inputs;
using Agenda.Infra.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Agenda.Domain.Tests.Account.Commands
{
    [TestClass]
    [TestCategory("User")]
    public class UserCommandHandlerTests
    {
        private readonly UserFakeRepository userRepository;
        private readonly UserCommandHandler _handler;

        public UserCommandHandlerTests()
        {
            userRepository = new UserFakeRepository();
            _handler = new UserCommandHandler(userRepository);
        }

        [TestMethod]
        public void Should_Create_A_User()
        {
            CreateUserCommand command = new CreateUserCommand()
            {
                Name = "Mabau",
                Password = "123456",
                Username = "mabau"
            };
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Update_A_User()
        {
            UpdateUserCommand command = new UpdateUserCommand()
            {
                UserId = userRepository.users.FirstOrDefault().Id,
                Name = "Mabau"
            };
            _handler.Handler(command);
            Assert.IsNotNull(_handler.Handler(command));
        }

        [TestMethod]
        public void Should_Change_A_User_Status()
        {
            UpdateUserStatusCommand command = new UpdateUserStatusCommand()
            {
                UserId = userRepository.users.FirstOrDefault().Id,
                Status = true
            };
            _handler.Handler(command);
            Assert.IsNotNull(_handler.Handler(command));
        }
    }
}
