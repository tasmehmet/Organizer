using AutoMapper;
using Organizer.Application.ViewModels;
using Organizer.Domain.Models;

namespace Organizer.Application.Automapper
{
    public class DomainToViewMappingProfile : Profile
    {
        public DomainToViewMappingProfile()
        {
            CreateMap<CityModel, CityViewModel>();
            CreateMap<CountiesModel, CountiesViewModel>();
        }
    }
}