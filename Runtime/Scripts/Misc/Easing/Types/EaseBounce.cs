namespace FreschGames.Core.Misc.Easing.Types
{
    public static class EaseBounce
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return 1f - Evaluate(1f - t, EaseDirection.EaseOut);
                case EaseDirection.EaseOut:
                    float threshold = .37f;
                    if (t < threshold)
                    {
                        return 7.5625f * t * t;
                    }
                    else if (t < threshold * 2f)
                    {
                        t = t - 1.5f * threshold;
                        return 7.5625f * t * t + 0.75f;
                    }
                    else if (t < threshold * 2.5f)
                    {
                        t = t - 2.25f * threshold;
                        return 7.5625f * t * t + 0.9375f;
                    }

                    t = t - 2.625f * threshold;
                    return 7.5625f * t * t + 0.984375f;
                case EaseDirection.EaseInOut:
                    if (t < 0.5f)
                        return 0.5f * Evaluate(t * 2f, EaseDirection.EaseIn);
                    return 0.5f * Evaluate(t * 2f - 1f, EaseDirection.EaseOut) + 0.5f;
            }

            return 0;
        }
    }
}