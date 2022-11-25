using UnityEngine;
using FGC.Misc;

namespace FGC.Misc.TransformTools
{
    public class LookAtTransform : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private UpdateType updateType;
        public UpdateType UpdateType { get { return updateType; } }

        [SerializeField] private Transform source;
        public Transform Source { get { return source; } private set { this.source = value; } }


        public void SetSource(Transform source)
        {
            this.Source = source;
        }


        private void Update()
        {
            if (this.UpdateType == UpdateType.Update)
            {
                this.UpdateTransform();
            }
        }

        private void LateUpdate()
        {
            if (this.UpdateType == UpdateType.LateUpdate)
            {
                this.UpdateTransform();
            }
        }

        private void FixedUpdate()
        {
            if (this.UpdateType == UpdateType.FixedUpdate)
            {
                this.UpdateTransform();
            }
        }

        public void ManualUpdate()
        {
            if (this.UpdateType == UpdateType.Manually)
            {
                this.UpdateTransform();
            }
        }

        private void UpdateTransform()
        {
            this.transform.LookAt(this.Source);
        }

    }
}