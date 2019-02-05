﻿namespace Agenda.SharedKernel.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
