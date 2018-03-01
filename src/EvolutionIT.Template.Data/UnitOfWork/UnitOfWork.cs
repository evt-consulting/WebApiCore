namespace EvolutionIT.Template.Data.UnitOfWork
{
    using EvolutionIT.Template.Data.Context;
    using EvolutionIT.Template.Domain.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return rowsAffected;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
