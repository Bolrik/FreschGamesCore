using FreschGames.Core.EventSystem;

namespace FreschGames.Core.ResourceSystem
{
    public static class Asset<T>
    {
        public static T Instance { get; private set; }

        public static void Assign(T instance)
        {
            T previous = Asset<T>.Instance;
            T current = Asset<T>.Instance = instance;

            Event<AssetChangedEvent<T>>.Invoke(new AssetChangedEvent<T>(previous, current));
        }
    }
}
