using UnityEngine;

namespace FreschGames.Core.BootSystem
{
    public abstract class BootStep : ScriptableObject
    {
        public abstract void Load();
    }
}
