using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FreschGames.Core.SmotionSystem
{
    // Smooth Motion
    class SmotionContainer
    {
        public float Time { get; private set; }
        public SmotionType Type { get; private set; }
        public SmotionDirection Direction { get; private set; }

        public float Value { get; private set; }


        public float Update(float deltaTime)
        {
            this.Time += deltaTime;

            return (this.Value = Smotion.Evaluate(this.Time, this.Type, this.Direction));
        }

        public float Update()
        {
            return this.Update(GameTime.DeltaTime);
        }
    }

    public static class Smotion
    {
        public static float Evaluate(float t, SmotionType type, SmotionDirection direction)
        {
            switch (type)
            {
                case SmotionType.Linear:
                    return Linear.Evaluate(t, direction);
                case SmotionType.Quadratic:
                    return Quadratic.Evaluate(t, direction);
                case SmotionType.Cubic:
                    return Cubic.Evaluate(t, direction);
                case SmotionType.Sine:
                    return Sine.Evaluate(t, direction);
                case SmotionType.Circular:
                    return Circular.Evaluate(t, direction);
                case SmotionType.Exponential:
                    return Exponential.Evaluate(t, direction);
                case SmotionType.Elastic:
                    return Elastic.Evaluate(t, direction);
                case SmotionType.Back:
                    return Back.Evaluate(t, direction);
                case SmotionType.Bounce:
                    return Bounce.Evaluate(t, direction);
                default:
                    return 0;
            }
        }


        static class Linear
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                return t;
            }
        }

        static class Quadratic
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        return t * t;
                    case SmotionDirection.Out:
                        return (t - 1f) * (t - 1f) + 1f;
                    case SmotionDirection.InOut:
                        if (t < 0.5f)
                            return 2f * t * t;
                        return (-2f * t * t) + (4f * t) - 1f;
                }

                return 0;
            }
        }

        static class Cubic
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        return t * t * t;
                    case SmotionDirection.Out:
                        return (t - 1f) * (t - 1f) * (t - 1f) + 1f;
                    case SmotionDirection.InOut:
                        if (t < 0.5f)
                            return 4f * t * t * t;
                        float p = 2f * t - 2f;
                        return 0.5f * p * p * p + 1f;
                }

                return 0;
            }
        }

        static class Exponential
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        if (t == 0f)
                            return 0f;
                        return Mathf.Pow(2, 10 * (t - 1));
                    case SmotionDirection.Out:
                        if (t == 1f)
                            return 1f;
                        return 1f - Mathf.Pow(2, -10 * t);
                    case SmotionDirection.InOut:
                        if (t == 0f || t == 1f)
                            return t;

                        if (t < 0.5f)
                            return 0.5f * Mathf.Pow(2, (20 * t) - 10);
                        return -0.5f * Mathf.Pow(2, (-20 * t) + 10) + 1f;

                }

                return 0;
            }
        }

        static class Circular
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        return 1f - Mathf.Sqrt(1f - (t * t));
                    case SmotionDirection.Out:
                        return Mathf.Sqrt((2f - t) * t);
                    case SmotionDirection.InOut:
                        if (t < 0.5f)
                            return 0.5f * (1f - Mathf.Sqrt(1f - 4f * (t * t)));
                        return 0.5f * (Mathf.Sqrt(-((2f * t) - 3f) * ((2f * t) - 1f)) + 1f);

                }

                return 0;
            }
        }

        static class Back
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                float p = 0;
                switch (direction)
                {
                    case SmotionDirection.In:
                        return t * t * t - t * Mathf.Sin(t * Mathf.PI);
                    case SmotionDirection.Out:
                        p = 1 - t;
                        return 1 - (p * p * p - p * Mathf.Sin(p * Mathf.PI));
                    case SmotionDirection.InOut:
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

        static class Sine
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        return Mathf.Sin((t - 1f) * Mathf.PI / 2) + 1f;
                    case SmotionDirection.Out:
                        return Mathf.Sin(t * Mathf.PI / 2); ;
                    case SmotionDirection.InOut:
                        return 0.5f * (1f - Mathf.Cos(t * Mathf.PI));
                }

                return 0;
            }
        }

        static class Bounce
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        return 1f - Evaluate(1f - t, SmotionDirection.Out);
                    case SmotionDirection.Out:
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
                    case SmotionDirection.InOut:
                        if (t < 0.5f)
                            return 0.5f * Evaluate(t * 2f, SmotionDirection.In);
                        return 0.5f * Evaluate(t * 2f - 1f, SmotionDirection.Out) + 0.5f;
                }

                return 0;
            }
        }

        static class Elastic
        {
            public static float Evaluate(float t, SmotionDirection direction)
            {
                switch (direction)
                {
                    case SmotionDirection.In:
                        return Mathf.Sin(13 * Mathf.PI / 2 * t) * Mathf.Pow(2, 10 * (t - 1));
                    case SmotionDirection.Out:
                        return Mathf.Sin(-13 * Mathf.PI / 2 * (t + 1)) * Mathf.Pow(2, -10 * t) + 1f;
                    case SmotionDirection.InOut:
                        if (t < 0.5f)
                            return 0.5f * Mathf.Sin(13 * Mathf.PI / 2 * (2 * t)) * Mathf.Pow(2, 10 * ((2 * t) - 1));
                        return 0.5f * (Mathf.Sin(-13 * Mathf.PI / 2 * ((2 * t - 1) + 1)) * Mathf.Pow(2, -10 * (2 * t - 1)) + 2f);


                }

                return 0;
            }
        }
    }

    public enum SmotionType
    {
        Linear = 0,
        Quadratic = 1,
        Cubic = 2,
        Sine = 3,
        Circular = 4,
        Exponential = 5,
        Elastic = 6,
        Back = 7,
        Bounce = 8
    }

    public enum SmotionDirection
    {
        In = 0,
        Out = 1,
        InOut = 2
    }
}