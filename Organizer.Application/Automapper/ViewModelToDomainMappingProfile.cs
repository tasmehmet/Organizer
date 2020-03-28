using AutoMapper;
using Organizer.Application.ViewModels;
using Organizer.Domain.Models;

namespace Organizer.Application.Automapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CityViewModel,CityModel>();
            CreateMap<CountiesViewModel,CountiesModel>();
        }
    }
}