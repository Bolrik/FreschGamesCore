namespace FreschGames.Core.EventSystem
{
    public static class Event<T> where T : IEvent
    {
        public delegate void GameEvent(T gameEvent);

        public static GameEvent OnEvent { get; set; }

        public static void Invoke(T gameEvent) => OnEvent?.Invoke(gameEvent);
    }
}
