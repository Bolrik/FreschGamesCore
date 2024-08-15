using FreschGames.Core.EventSystem;

namespace FreschGames.Core.ResourceSystem
{
    public abstract class ResourceChangedEvent<T> : IEvent
    {
        public abstract ResourceType Type { get; }
        public T Previous { get; private set; }
        public T Current { get; private set; }


        public ResourceChangedEvent(T previous, T current)
        {
            this.Previous = previous;
            this.Current = current;
        }
    }
}
