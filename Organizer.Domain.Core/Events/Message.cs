using System;
using MediatR;

namespace Organizer.Domain.Core.Events
{
    public abstract class Message<T> : IRequest<T>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}