using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Organizer.Data.Context;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;
using System.Linq;

namespace Organizer.Data.Repository
{
    public class CityRepository: Repository<CityModel>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public CityModel GetCities()
        {
            return DbSet.FirstOrDefault();
        }
    }
}