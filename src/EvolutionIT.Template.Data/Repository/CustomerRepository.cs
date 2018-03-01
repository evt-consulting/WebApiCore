namespace EvolutionIT.Template.Data.Repository
{
    using EvolutionIT.Template.Data.Context;
    using EvolutionIT.Template.Domain.Interfaces;
    using EvolutionIT.Template.Domain.Models;

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) 
            : base(context)
        {
        }        
    }
}
