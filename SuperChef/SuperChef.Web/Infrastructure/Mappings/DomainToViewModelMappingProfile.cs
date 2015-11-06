using AutoMapper;
using SuperChef.Core.Entities;
using SuperChef.Web.ViewModels;

namespace SuperChef.Web.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Chef, ChefViewModel>();
        }
    }
}