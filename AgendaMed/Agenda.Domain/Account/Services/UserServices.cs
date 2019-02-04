using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Account.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(string username, string password, string name)
        {
            User user = new User(username, password, name);
            if (!user.IsValid())
                return;
            _userRepository.Save(user);
        }

        public void Update(Guid id, string name)
        {
            User user = _userRepository.GetById(id);
            user.Update(name);
            if (!user.IsValid())
                return;
            _userRepository.Update(user);
        }

        public void ChangeStatus(Guid id, bool status)
        {
            User user = _userRepository.GetById(id);
            if (status)
                user.Activate();
            else
                user.Deactivate();
            _userRepository.Update(user);
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
