using Agenda.Domain.Account.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        User GetById(Guid id);
        List<User> Users();
    }
}
