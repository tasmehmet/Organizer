using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizer.Domain.Core.Notifications;
using Organizer.Domain.Interfaces;
using Organizer.Web.Models;

namespace Organizer.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICityRepository _cityRepository;

        public HomeController(INotificationHandler<DomainNotification> notifications
            ,ICityRepository cityRepository):base(notifications)
        {
            _cityRepository = cityRepository;
        }
        public IActionResult Index()
        {
            var a = _cityRepository.GetCities();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}