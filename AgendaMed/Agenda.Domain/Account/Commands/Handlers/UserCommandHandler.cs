using Agenda.Domain.Account.Commands.Inputs;
using Agenda.Domain.Account.Commands.Results;
using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using Agenda.SharedKernel.Commands;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Account.Commands.Handlers
{
    public class UserCommandHandler : 
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<UpdateUserCommand>,
        ICommandHandler<UpdateUserStatusCommand>
    {
        private readonly IUserRepository _userRepository;
        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public ICommandResult Handler(CreateUserCommand command)
        {
            User user = new User(command.Username, command.Password, command.Name);
            if (!user.IsValid())
                return null;
            _userRepository.Save(user);
            return new StandardUserCommandResult(user.Id, DateTime.Now);
        }

        public ICommandResult Handler(UpdateUserCommand command)
        {
            User user = _userRepository.GetById(command.UserId);
            user.Update(command.Name);
            if (!user.IsValid())
                return null;
            _userRepository.Update(user);
            return new StandardUserCommandResult(user.Id, DateTime.Now);
        }

        public ICommandResult Handler(UpdateUserStatusCommand command)
        {
            User user = _userRepository.GetById(command.UserId);
            if (command.Status)
                user.Activate();
            else
                user.Deactivate();
            _userRepository.Update(user);
            return new StandardUserCommandResult(user.Id, DateTime.Now);
        }

        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> Users(Guid id)
        {
            return _userRepository.Users();
        }
    }
}
