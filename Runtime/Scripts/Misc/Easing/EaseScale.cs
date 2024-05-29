    using FreschGames.Core.Misc.Easing;
    using UnityEngine;

namespace FreschGames.Core.Misc.Easing
{
    public class EaseScale : MonoBehaviour
    {
        [field: SerializeField] private Transform Target { get; set; }
        [field: SerializeField] private Vector3 ScaleTarget { get; set; }
        [field: SerializeField] private Vector3 ScaleOrigin { get; set; }
        [field: SerializeField] private float Duration { get; set; } = 1f;
        [field: SerializeField] private EaseType Type { get; set; } = EaseType.Linear;
        [field: SerializeField] private EaseDirection Direction { get; set; } = EaseDirection.EaseIn;


        [field: SerializeField] public EaseMode Mode { get; private set; }


        private float Timer { get; set; }

        private void Awake()
        {
            if (this.Target == null)
                this.Target = this.transform;

            //this.InitialScale = this.Target.localScale;
        }

        private void Update()
        {
            this.Timer += Time.deltaTime;

            float t = Mathf.Clamp01(this.Timer / this.Duration);
            this.ApplyTween(t);

            if (this.Timer >= this.Duration)
            {
                this.Timer = 0f;

                if (this.Mode == EaseMode.PingPong)
                {
                    this.SwapScale();
                }
                else
                {
                    this.Target.localScale = this.ScaleTarget;

                    if (this.Mode != EaseMode.Loop)
                        this.enabled = false;
                }
            }
        }

        private void ApplyTween(float t)
        {
            switch (this.Type)
            {
                case EaseType.Linear:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseLinear.Evaluate(t, this.Direction));
                    break;
                case EaseType.Quadratic:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseQuadratic.Evaluate(t, this.Direction));
                    break;
                case EaseType.Cubic:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseCubic.Evaluate(t, this.Direction));
                    break;
                case EaseType.Sine:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseSine.Evaluate(t, this.Direction));
                    break;
                case EaseType.Circular:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseCircular.Evaluate(t, this.Direction));
                    break;
                case EaseType.Exponential:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseExponential.Evaluate(t, this.Direction));
                    break;
                case EaseType.Elastic:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseElastic.Evaluate(t, this.Direction));
                    break;
                case EaseType.Back:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseBack.Evaluate(t, this.Direction));
                    break;
                case EaseType.Bounce:
                    this.Target.localScale = Vector3.Lerp(this.ScaleOrigin, this.ScaleTarget, EaseBounce.Evaluate(t, this.Direction));
                    break;
                default:
                    break;
            }
        }

        private void SwapScale()
        {
            Vector3 tempScale = this.ScaleOrigin;
            this.ScaleOrigin = this.ScaleTarget;
            this.ScaleTarget = tempScale;
        }

        private float Bounce(float t)
        {
            float threshold = 1f / 2.75f;

            if (t < threshold)
            {
                Debug.Log("0");
                return 7.5625f * t * t;
            }
            else if (t < 2f * threshold)
            {
                Debug.Log("1");
                t = t - 1.5f * threshold;
                return 7.5625f * t * t + 0.75f;
            }
            else if (t < 2.5f * threshold)
            {
                Debug.Log("2");
                t = t - 2.25f * threshold;
                return 7.5625f * t * t + 0.9375f;
            }
            else
            {
                Debug.Log("3");
                t = t - 2.625f * threshold;
                return 7.5625f * t * t + 0.984375f;
            }
        }


        public void Set(Vector3 scaleOrigin, Vector3 scaleTarget, EaseType type, EaseDirection direction, EaseMode mode)
        {
            this.ScaleOrigin = scaleOrigin;
            this.ScaleTarget = scaleTarget;

            this.Type = type;
            this.Direction = direction;
            this.Mode = mode;
        }

        public void Set(EaseType type, EaseDirection direction, EaseMode mode)
        {
            this.Set(Vector3.zero, Vector3.one, type, direction, mode);
        }

        public void Set(EaseType type, EaseDirection direction)
        {
            this.Set(type, direction, EaseMode.Once);
        }
    }
}