using Agenda.SharedKernel.Entities;
using FluentValidator;
using System.Text;

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

            new ValidationContract<User>(this)
                .IsRequired(x => x.Username, "O nome do usuario deve ser informado.")
                .IsRequired(x => x.Password, "A senha deve ser informada.")

                .HasMinLenght(x => x.Password, 4, "A senha deve ter no minimo 4 caracteres.")

                .HasMaxLenght(x => x.Username, 20, "O nome de usuário deve ter no máximo 20 caracteres.")
                .HasMaxLenght(x => x.Password, 20, "A senha do usuário deve ter no máximo 20 caracteres.")
                .HasMaxLenght(x => x.Name, 100, "O nome do usuário deve ter no máximo 100 caracteres.");

            EncryptPassword(Password);
        }

        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Update(string name)
        {
            Name = name;

            new ValidationContract<User>(this)
                .HasMaxLenght(x => x.Name, 100, "O nome do usuário deve ter no máximo 100 caracteres.");
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

        public bool Authenticate(string username, string password)
        {
            var passwordHash = EncryptPassword(password);
            if (Username.Equals(username) && Password.Equals(passwordHash))
                return true;
            return false;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "8b11d678-9af7-4f3a-a28a-4de7e1826e20");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));
            return sbString.ToString();
        }
    }
}
