using FreschGames.Core.EventSystem;

namespace FreschGames.Core.ResourceSystem
{
    public static class State<T>
    {
        public static T Instance { get; private set; }

        public static void Assign(T instance)
        {
            T previous = State<T>.Instance;
            T current = State<T>.Instance = instance;

            Event<StateChangedEvent<T>>.Invoke(new StateChangedEvent<T>(previous, current));
        }
    }
}
