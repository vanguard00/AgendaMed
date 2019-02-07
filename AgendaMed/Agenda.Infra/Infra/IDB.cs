using System;
using System.Data;

namespace Agenda.Infra.Infra
{
    public interface IDB : IDisposable
    {
        IDbConnection connection();
    }
}
