using UnityEngine;

namespace FreschGames.Core.Misc.Easing.Types
{
    public static class EaseBack
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            float p = 0;
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return t * t * t - t * Mathf.Sin(t * Mathf.PI);
                case EaseDirection.EaseOut:
                    p = 1 - t;
                    return 1 - (p * p * p - p * Mathf.Sin(p * Mathf.PI));
                case EaseDirection.EaseInOut:
                    if (t < 0.5f)
                    {
                        p = 2 * t;
                        return 0.5f * (p * p * p - p * Mathf.Sin(p * Mathf.PI));
                    }

                    float q = 1 - (2 * t - 1);

                    return 0.5f * (1 - (q * q * q - q * Mathf.Sin(q * Mathf.PI))) + 0.5f;
            }

            return 0;
        }
    }
}