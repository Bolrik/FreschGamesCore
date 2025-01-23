using FreschGames.Core.EventSystem;
using System;

namespace FreschGames.Core.StateSystem
{
    public static class State<T>
    {
        public static T Instance { get; private set; }
        public static Action<StateChangedEvent<T>> OnStateChanged { get; set; }

        public static void Assign(T instance)
        {
            T oldState = Instance;
            T newState = Instance = instance;

            Event<StateChangedEvent<T>>.Invoke(new StateChangedEvent<T>(oldState, newState));
        }
    }
}
