using AutoMapper;
using SuperChef.Core.Entities;
using SuperChef.Web.ViewModels;

namespace SuperChef.Web.Infrastructure.Mappings
{
    public class ChefMappingProfile : Profile
    {
        public ChefMappingProfile() : base("ChefProfile")
        {
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Chef, ChefIndexViewModel>();
            Mapper.CreateMap<Chef, ChefDetailsViewModel>();

            Mapper.CreateMap<Chef, ChefEditViewModel>()
                .ForMember(vm => vm.ChefName, map => map.MapFrom(c => c.UserName));

            Mapper.CreateMap<ChefEditViewModel, Chef>()
                .ForMember(c => c.UserName, map => map.MapFrom(vm => vm.ChefName));
        }
    }
}