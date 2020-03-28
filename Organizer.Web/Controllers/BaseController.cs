using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizer.Domain.Core.Notifications;

namespace Organizer.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }
        
        public IEnumerable<(string,string)> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(p => (p.Key, p.Value));
        }
    }
}