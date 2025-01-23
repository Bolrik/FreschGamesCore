using FreschGames.Core.EventSystem;

namespace FreschGames.Core.StateSystem
{
    public class StateChangedEvent<T> : IEvent
    {
        public T OldState { get; private set; }
        public T NewState { get; private set; }

        public StateChangedEvent(T oldState, T newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }
    }
}
