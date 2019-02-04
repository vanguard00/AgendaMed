using Agenda.Domain.Account.Entities;
using Agenda.Domain.Account.Repositories;
using Agenda.Domain.Account.Services;
using Agenda.Domain.Management.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class UserRepository : IUserRepository
    {
        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> Users()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserServices userServices = new UserServices(new UserRepository());
            userServices.Create("vanguard", "123", "israel");
            Console.ReadKey();
        }
    }
}
