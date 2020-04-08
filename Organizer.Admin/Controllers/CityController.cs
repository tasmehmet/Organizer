using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organizer.Application.ViewModels;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;

namespace Organizer.Admin.Controllers
{

    public class CityController : Controller
    {
        public readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(CityModel a)
        {
            _cityRepository.Add(a);
            _cityRepository.SaveChanges();
            return RedirectToAction("Index", "City");
        }
    }
}