using UnityEngine;

namespace FreschGames.Core.Misc.Info
{
    public class TransformPositionDeltaDebug : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private UpdateType updateType;
        public UpdateType UpdateType { get { return updateType; } }

        [SerializeField] private Transform source;
        public Transform Source { get { return source; } private set { this.source = value; } }

        [SerializeField] private float sampleTime;
        public float SampleTime { get { return sampleTime; } }


        [Header("Check")]
        [SerializeField] private bool x;
        public bool X { get { return x; } }

        [SerializeField] private bool y;
        public bool Y { get { return y; } }

        [SerializeField] private bool z;
        public bool Z { get { return z; } }



        Vector3 PreviousPosition { get; set; }
        float SampleTimeCount { get; set; }

        public void SetSource(Transform source)
        {
            this.Source = source;
        }


        private void Update()
        {
            if (this.UpdateType == UpdateType.Update)
            {
                this.UpdateCheck(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (this.UpdateType == UpdateType.LateUpdate)
            {
                this.UpdateCheck(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (this.UpdateType == UpdateType.FixedUpdate)
            {
                this.UpdateCheck(Time.fixedDeltaTime);
            }
        }

        public void ManualUpdate()
        {
            if (this.UpdateType == UpdateType.Manually)
            {
                this.UpdateCheck(0);
            }
        }

        private void UpdateCheck(float sampleTime)
        {
            if (this.Source == null)
                return;

            this.SampleTimeCount += sampleTime;

            if (this.SampleTimeCount < this.SampleTime)
            {
                return;
            }

            Vector3 currentPosition = this.Source.position;

            Vector3 delta = (currentPosition - this.PreviousPosition) / this.SampleTimeCount * this.SampleTime;

            this.PreviousPosition = this.PreviousPosition + delta;

            if (!this.X)
                delta.x = 0;
            if (!this.Y)
                delta.y = 0;
            if (!this.Z)
                delta.z = 0;

            UnityEngine.Debug.Log($"{delta.magnitude / this.SampleTime,-10:N2} {currentPosition} {this.PreviousPosition}");
            this.SampleTimeCount -= this.SampleTime;
        }
    }
}