using System;

namespace ControleDeCustos.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
