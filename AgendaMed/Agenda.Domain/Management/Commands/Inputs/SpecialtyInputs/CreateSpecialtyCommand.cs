using Agenda.SharedKernel.Commands;

namespace Agenda.Domain.Management.Commands.Inputs.SpecialtyInputs
{
    public class CreateSpecialtyCommand : ICommand
    {
        public string Name { get; set; }
    }
}
