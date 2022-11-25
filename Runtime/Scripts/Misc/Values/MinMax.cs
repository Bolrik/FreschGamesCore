using UnityEngine;

namespace FreschGames.Core.Misc
{
    [System.Serializable]
    public class MinMax<Type>
    {
        [SerializeField] private Type min;
        public Type Min { get { return min; } }

        [SerializeField] private Type max;
        public Type Max { get { return max; } }
    }
}