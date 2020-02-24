using System;

namespace Organizer.Domain.Core.Events
{
    public class Event:Message<bool>, MediatR.INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}