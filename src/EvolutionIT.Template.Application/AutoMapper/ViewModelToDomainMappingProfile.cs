
namespace EvolutionIT.Template.Application.AutoMapper
{
    using global::AutoMapper;
    using EvolutionIT.Template.Application.ViewModels;
    using EvolutionIT.Template.Domain.Models;

    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}