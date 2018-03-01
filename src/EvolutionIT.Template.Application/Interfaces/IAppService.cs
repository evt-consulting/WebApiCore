namespace EvolutionIT.Template.Application.Interfaces
{
    using EvolutionIT.Template.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    public interface IAppService<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByIdNoTracking(int id);
        void Update(TEntity customer);
        void Remove(int id);
        void Add(TEntity obj);
        bool Any(Func<TEntity, bool> func);
    }
}
