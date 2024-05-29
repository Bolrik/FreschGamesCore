using UnityEngine;

namespace FreschGames.Core.Misc.Easing
{
    internal static class EaseCircular
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return 1f - Mathf.Sqrt(1f - (t * t));
                case EaseDirection.EaseOut:
                    return Mathf.Sqrt((2f - t) * t);
                case EaseDirection.EaseInOut:
                    if (t < 0.5f)
                        return 0.5f * (1f - Mathf.Sqrt(1f - 4f * (t * t)));
                    return 0.5f * (Mathf.Sqrt(-((2f * t) - 3f) * ((2f * t) - 1f)) + 1f);

            }

            return 0;
        }
    }
}