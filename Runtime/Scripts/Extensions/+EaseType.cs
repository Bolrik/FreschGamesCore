using FreschGames.Core.Misc.Easing;
using FreschGames.Core.Misc.Easing.Types;

namespace UnityEngine
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
    }
}
