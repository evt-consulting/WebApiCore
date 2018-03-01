namespace EvolutionIT.Template.Data.Repository
{
    using EvolutionIT.Template.Data.Context;
    using EvolutionIT.Template.Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext AppDbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext context)
        {
            AppDbContext = context;
            DbSet = AppDbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return AppDbContext.SaveChanges();
        }

        public void Dispose()
        {
            AppDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Any(Func<TEntity, bool> func)
        {
            return DbSet.Any(func);
        }

        public void Attach(TEntity obj)
        {
            AppDbContext.Attach(obj);
        }

        public void Detach(TEntity obj)
        {
            AppDbContext.Entry(obj).State = EntityState.Detached;
        }
    }
}
