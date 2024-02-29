using System;

namespace FreschGames.Core.Misc.Easing.Types
{
    public static partial class Extension
    {
        public static float Evaluate(this EaseType easeType, float t, EaseDirection direction)
        {
            switch (easeType)
            {
                case EaseType.Linear:
                    return EaseLinear.Evaluate(t, direction);
                case EaseType.Quadratic:
                    return EaseQuadratic.Evaluate(t, direction);
                case EaseType.Cubic:
                    return EaseCubic.Evaluate(t, direction);
                case EaseType.Sine:
                    return EaseSine.Evaluate(t, direction);
                case EaseType.Circular:
                    return EaseCircular.Evaluate(t, direction);
                case EaseType.Exponential:
                    return EaseExponential.Evaluate(t, direction);
                case EaseType.Elastic:
                    return EaseElastic.Evaluate(t, direction);
                case EaseType.Back:
                    return EaseBack.Evaluate(t, direction);
                case EaseType.Bounce:
                    return EaseBounce.Evaluate(t, direction);

                default:
                    return t;
            }
        }

        public static float Evaluate(this EaseType easeType, float t, EaseDirection direction, EaseMode mode)
        {
            switch (mode)
            {
                case EaseMode.Once:
                    return Evaluate(easeType, t.Clamp01(), direction);
                case EaseMode.Loop:
                    return Evaluate(easeType, t.Loop(1), direction);
                case EaseMode.PingPong:
                    return Evaluate(easeType, t.PingPong(1), direction);
                case EaseMode.None:
                default:
                    return Evaluate(easeType, t, direction);
            }
        }
    }
}
