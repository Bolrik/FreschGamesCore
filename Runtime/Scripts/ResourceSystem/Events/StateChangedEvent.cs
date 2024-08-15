namespace FreschGames.Core.ResourceSystem
{
    public class StateChangedEvent<T> : ResourceChangedEvent<T>
    {
        public override ResourceType Type => ResourceType.State;


        public StateChangedEvent(T previous, T current) : base(previous, current) { }
    }
}
