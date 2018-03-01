namespace EvolutionIT.Template.Domain.Interfaces
{
    using System;
    using System.Linq;

    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        bool Any(Func<TEntity, bool> func);
        int SaveChanges();
        void Attach(TEntity obj);
        void Detach(TEntity obj);
    }
}
