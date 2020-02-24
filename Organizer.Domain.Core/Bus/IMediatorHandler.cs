using System.Threading.Tasks;
using Organizer.Domain.Core.Commands;
using Organizer.Domain.Core.Events;

namespace Organizer.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}