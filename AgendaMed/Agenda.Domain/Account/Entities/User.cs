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
            
            if(string.IsNullOrWhiteSpace(username))
                AddNotification("Username", "O username deve ser informado.");
            if (string.IsNullOrWhiteSpace(password))
                AddNotification("Password", "A senha deve ser informada.");
            if (username.Length > 20)
                AddNotification("Username", "O username deve ter no máximo 20 caracteres.");
            if (password.Length < 4)
                AddNotification("Password", "A senha deve ter no minimo 4 caracteres.");
            if (name.Length > 100)
                AddNotification("Name", "O nome do usuário ter no máximo 100 caracteres.");
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
