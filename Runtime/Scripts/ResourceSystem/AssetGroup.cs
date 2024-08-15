using UnityEngine;

namespace FreschGames.Core.ResourceSystem
{
    public abstract class AssetGroup : ScriptableObject
    {
        protected void Assign<T>(T value)
        {
            Asset<T>.Assign(value);
        }

        public abstract void Load();
    }
}
