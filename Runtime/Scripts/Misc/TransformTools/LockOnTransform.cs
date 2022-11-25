using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FreschGames.Misc;

namespace FreschGames.Misc.TransformTools
{
    public class LockOnTransform : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private UpdateType updateType;
        public UpdateType UpdateType { get { return updateType; } }

        [SerializeField] private Transform source;
        public Transform Source { get { return source; } private set { this.source = value; } }

        [Header("Rules")]
        [SerializeField] private bool posX;
        public bool PosX { get { return posX; } }

        [SerializeField] private bool posY;
        public bool PosY { get { return posY; } }

        [SerializeField] private bool posZ;
        public bool PosZ { get { return posZ; } }

        [SerializeField] private bool rotX;
        public bool RotX { get { return rotX; } }

        [SerializeField] private bool rotY;
        public bool RotY { get { return rotY; } }

        [SerializeField] private bool rotZ;
        public bool RotZ { get { return rotZ; } }


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
            if (this.Source == null)
                return;

            Vector3 position, euler;

            position = this.transform.position;
            euler = this.transform.eulerAngles;

            if (this.PosX)
                position.x = this.Source.position.x;
            if (this.PosY)
                position.y = this.Source.position.y;
            if (this.PosZ)
                position.z = this.Source.position.z;

            if (this.RotX)
                euler.x = this.Source.eulerAngles.x;
            if (this.RotY)
                euler.y = this.Source.eulerAngles.y;
            if (this.RotZ)
                euler.z = this.Source.eulerAngles.z;

            this.transform.position = position;
            this.transform.eulerAngles = euler;
        }
    }
}