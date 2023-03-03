using UnityEngine;

namespace FreschGames.Core.Managers
{
    public abstract class ManagerComponent : ScriptableObject
    {
        public abstract void DoAwake();
        public abstract void DoStart();
        public abstract void DoUpdate();
        public abstract void DoLateUpdate();
    }
}