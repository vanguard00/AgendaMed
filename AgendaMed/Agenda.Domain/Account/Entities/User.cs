using Agenda.SharedKernel.Entities;

namespace Agenda.Domain.Account.Entities
{
    public class User : Entity
    {
        public User(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;
            Active = true;
        }

        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }
    }
}
