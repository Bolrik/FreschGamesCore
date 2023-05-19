using UnityEngine;

namespace FreschGames.Core.Misc.Easing.Types
{

    public static class EaseSine
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return Mathf.Sin((t - 1f) * Mathf.PI / 2) + 1f;
                case EaseDirection.EaseOut:
                    return Mathf.Sin(t * Mathf.PI / 2); ;
                case EaseDirection.EaseInOut:
                    return 0.5f * (1f - Mathf.Cos(t * Mathf.PI));
            }

            return 0;
        }
    }
}