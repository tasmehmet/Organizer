using System.Collections.Generic;
using Organizer.Domain.Models;

namespace Organizer.Domain.Interfaces
{
    public interface ICityRepository: IRepository<CityModel>
    {
        CityModel GetCities();
    }
}