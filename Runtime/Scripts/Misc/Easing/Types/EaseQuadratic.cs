namespace FreschGames.Core.Misc.Easing
{
    internal static class EaseQuadratic
    {
        public static float Evaluate(float t, EaseDirection direction)
        {
            switch (direction)
            {
                case EaseDirection.EaseIn:
                    return t * t;
                case EaseDirection.EaseOut:
                    return -(t * (t - 2f));
                case EaseDirection.EaseInOut:
                    if (t < 0.5f)
                        return 2f * t * t;
                    return (-2f * t * t) + (4f * t) - 1f;
            }

            return 0;
        }
    }
}