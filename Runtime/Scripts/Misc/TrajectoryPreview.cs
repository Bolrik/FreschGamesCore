using System;
using System.Collections.Generic;
using UnityEngine;

namespace FGC.Misc
{
    public class TrajectoryPreview : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        public LineRenderer LineRenderer { get { return this.lineRenderer; } }

        [SerializeField] private Vector3 force;
        public Vector3 Force { get { return this.force; } private set { this.force = value; } }

        [SerializeField] private float previewTime;
        public float PreviewTime { get { return previewTime; } }

        [Range(.1f, .25f)]
        [SerializeField] private float iterationTime;
        public float IterationTime { get { return this.iterationTime; } }

        [SerializeField] private LayerMask collisionMask;
        public LayerMask CollisionMask { get { return collisionMask; } }

        [SerializeField] private Transform origin;
        public Transform Origin { get { return origin != null ? this.origin : this.transform; } private set { this.origin = value; } }


        List<Vector3> Points { get; set; } = new List<Vector3>();

        public void SetForce(Vector3 force)
        {
            this.Force = force;
            this.CalculatePoints();
        }

        public void SetVisible(bool value)
        {
            this.LineRenderer.enabled = value;
        }
        
        public void SetOrigin(Transform origin)
        {
            this.Origin = origin;
        }

        private void CalculatePoints()
        {
            this.Points.Clear();

            Vector3 startPosition = this.Origin.position;
            Vector3 startVelocity = this.Force;

            Vector3 previousPosition = startPosition;

            int i = 0;

            for (float time = 0; time < this.PreviewTime; time += this.IterationTime.ClampMin(.1f))
            {
                i++;
                Vector3 point = startPosition + time * startVelocity;
                point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

                if (Physics.Raycast(previousPosition,
                    (point - previousPosition).normalized,
                    out RaycastHit hit,
                    (point - previousPosition).magnitude,
                    this.CollisionMask))
                {
                    this.Points.Add(hit.point);
                    break;
                }

                this.Points.Add(point);
                previousPosition = point;
            }

            this.LineRenderer.positionCount = this.Points.Count;
            this.LineRenderer.SetPositions(this.Points.ToArray());
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                this.CalculatePoints();

            foreach (var point in this.Points)
            {
                Gizmos.DrawWireSphere(point, .15f);
            }
        }
    }
}