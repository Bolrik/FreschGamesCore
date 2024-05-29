using UnityEngine;

namespace FreschGames.Core.Misc.Easing
{
    internal static class EaseExponential
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    if (t == 0f)
                        return 0f;
                    return Mathf.Pow(2, 10 * (t - 1));
                case EaseDirection.EaseOut:
                    if (t == 1f)
                        return 1f;
                    return 1f - Mathf.Pow(2, -10 * t);
                case EaseDirection.EaseInOut:
                    if (t == 0f || t == 1f)
                        return t;

                    if (t < 0.5f)
                        return 0.5f * Mathf.Pow(2, (20 * t) - 10);
                    return -0.5f * Mathf.Pow(2, (-20 * t) + 10) + 1f;

            }

            return 0;
        }
    }
}