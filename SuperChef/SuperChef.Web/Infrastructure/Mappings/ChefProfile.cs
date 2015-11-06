using AutoMapper;
using SuperChef.Core.Entities;
using SuperChef.Web.ViewModels;

namespace SuperChef.Web.Infrastructure.Mappings
{
    public class ChefProfile : Profile
    {
        public ChefProfile() : base("ChefProfile")
        {
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Chef, ChefIndexViewModel>();
        }
    }
}