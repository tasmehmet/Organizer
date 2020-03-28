using System.Collections.Generic;
using Organizer.Application.ViewModels;

namespace Organizer.Application.Interfaces
{
    public interface ICityApplication:IApplicationService
    {
        CityViewModel GetCities();
    }
}