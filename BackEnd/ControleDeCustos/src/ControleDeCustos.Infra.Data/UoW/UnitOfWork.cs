using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;
using System;

namespace ControleDeCustos.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CDCContext _context;

        public UnitOfWork(CDCContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
