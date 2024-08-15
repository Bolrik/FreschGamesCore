namespace FreschGames.Core.ResourceSystem
{
    public class AssetChangedEvent<T> : ResourceChangedEvent<T>
    {
        public override ResourceType Type => ResourceType.Asset;

        public AssetChangedEvent(T previous, T current) : base(previous, current) { }
    }
}
