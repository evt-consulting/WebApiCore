using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionIT.Template.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
