namespace Organizer.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message<T>
    {
        void Handle(T message);
    }
}