using UnityEngine;

namespace FreschGames.Misc.Info
{
    public class RigidbodyVelocityDebug : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private UpdateType updateType;
        public UpdateType UpdateType { get { return updateType; } }

        [SerializeField] private Rigidbody source;
        public Rigidbody Source { get { return source; } private set { this.source = value; } }


        [Header("Check")]
        [SerializeField] private bool x;
        public bool X { get { return x; } }

        [SerializeField] private bool y;
        public bool Y { get { return y; } }

        [SerializeField] private bool z;
        public bool Z { get { return z; } }


        public void SetSource(Rigidbody source)
        {
            this.Source = source;
        }


        private void Update()
        {
            if (this.UpdateType == UpdateType.Update)
            {
                this.UpdateCheck();
            }
        }

        private void LateUpdate()
        {
            if (this.UpdateType == UpdateType.LateUpdate)
            {
                this.UpdateCheck();
            }
        }

        private void FixedUpdate()
        {
            if (this.UpdateType == UpdateType.FixedUpdate)
            {
                this.UpdateCheck();
            }
        }

        public void ManualUpdate()
        {
            if (this.UpdateType == UpdateType.Manually)
            {
                this.UpdateCheck();
            }
        }

        private void UpdateCheck()
        {
            if (this.Source == null)
                return;

            Vector3 velocity = this.Source.velocity;

            if (!this.X)
                velocity.x = 0;
            if (!this.Y)
                velocity.y = 0;
            if (!this.Z)
                velocity.z = 0;
            
            UnityEngine.Debug.Log($"{velocity.magnitude,-10:N3}");
        }
    }
}