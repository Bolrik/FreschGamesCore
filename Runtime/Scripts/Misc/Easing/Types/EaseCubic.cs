namespace FreschGames.Core.Misc.Easing.Types
{
    internal static class EaseCubic
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return t * t * t;
                case EaseDirection.EaseOut:
                    return(t - 1f) * (t - 1f) * (t - 1f) + 1f;
                case EaseDirection.EaseInOut:
                    if (t < 0.5f)
                        return 4f * t * t * t;
                    float p = 2f * t - 2f;
                    return 0.5f * p * p * p + 1f;
            }

            return 0;
        }
    }
}