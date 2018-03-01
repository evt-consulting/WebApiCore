namespace EvolutionIT.Template.CrossCutting.IoC
{
    using AutoMapper;
    using EvolutionIT.Template.Application.Interfaces;
    using EvolutionIT.Template.Application.Services;
    using EvolutionIT.Template.Data.Context;
    using EvolutionIT.Template.Data.Repository;
    using EvolutionIT.Template.Data.UnitOfWork;
    using EvolutionIT.Template.Domain.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // AutoMapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Infra - Data            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();

        }
    }
}
