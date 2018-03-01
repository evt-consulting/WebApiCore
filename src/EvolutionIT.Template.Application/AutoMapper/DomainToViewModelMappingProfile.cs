namespace EvolutionIT.Template.Application.AutoMapper
{
    using global::AutoMapper;
    using EvolutionIT.Template.Application.ViewModels;
    using EvolutionIT.Template.Domain.Models;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}