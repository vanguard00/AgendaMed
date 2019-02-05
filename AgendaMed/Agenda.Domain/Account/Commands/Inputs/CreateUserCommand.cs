using Agenda.SharedKernel.Commands;

namespace Agenda.Domain.Account.Commands.Inputs
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
