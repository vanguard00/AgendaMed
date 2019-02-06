using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Infra.FakeRepositories
{
    public class UserFakeRepository : IUserRepository
    {
        public List<User> users = new List<User>();
        public UserFakeRepository()
        {
            User user = new User("Vuyro", "123456", "Vuyro da Silva");
            User user2 = new User("Soisuwa", "123456", "Soisuwa Ferreira");
            users.Add(user);
            users.Add(user2);
        }
        public User GetById(Guid id)
        {
            return users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Save(User user)
        {
            users.Add(user);
        }

        public void Update(User user)
        {
            int index = users.IndexOf(user);
            users.RemoveAt(index);
            users.Insert(index, user);
        }

        public List<User> Users()
        {
            return users;
        }
    }
}
