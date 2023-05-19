using UnityEngine;

namespace FreschGames.Core.Misc.Easing.Types
{
    public static class EaseElastic
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return Mathf.Sin(13 * Mathf.PI / 2 * t) * Mathf.Pow(2, 10 * (t - 1));
                case EaseDirection.EaseOut:
                    return Mathf.Sin(-13 * Mathf.PI / 2 * (t + 1)) * Mathf.Pow(2, -10 * t) + 1f;
                case EaseDirection.EaseInOut:
                    if (t < 0.5f)
                        return 0.5f * Mathf.Sin(13 * Mathf.PI / 2 * (2 * t)) * Mathf.Pow(2, 10 * ((2 * t) - 1));
                    return 0.5f * (Mathf.Sin(-13 * Mathf.PI / 2 * ((2 * t - 1) + 1)) * Mathf.Pow(2, -10 * (2 * t - 1)) + 2f);


            }

            return 0;
        }
    }
}