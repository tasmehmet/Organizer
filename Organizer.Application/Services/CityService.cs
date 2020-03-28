using System;
using System.Collections.Generic;
using AutoMapper;
using Organizer.Application.Interfaces;
using Organizer.Application.ViewModels;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;

namespace Organizer.Application.Services
{
    public class CityService : ICityApplication
    {
        private ICityRepository _cityRepository;
        private IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public CityViewModel GetCities()
        {
            var data = _cityRepository.GetCities();
            return _mapper.Map<CityViewModel>(data);
        }
    }
}