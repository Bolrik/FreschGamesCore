using FreschGames.Core.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreschGames.Core.Systems
{
    public abstract class SystemComponent<T> : MonoBehaviour
        where T : ManagerComponent
    {
        [field: SerializeField, Header("Manager")] public T Manager { get; private set; }

        private void Awake()
        {
            this.PreAwake();
            this.Manager.DoAwake();
            this.OnAwake();
        }

        private void Start()
        {
            this.PreStart();
            this.Manager.DoStart();
            this.OnStart();
        }

        private void Update()
        {
            this.PreUpdate();
            this.Manager.DoUpdate();
            this.OnUpdate();
        }

        private void LateUpdate()
        {
            this.PreLateUpdate();
            this.Manager.DoLateUpdate();
            this.OnLateUpdate();
        }

        /// <summary>
        /// Is called, right before the Managers DoAwake is called.
        /// </summary>
        protected abstract void PreAwake();
        protected abstract void OnAwake();

        /// <summary>
        /// Is called, right before the Managers DoStart is called.
        /// </summary>
        protected abstract void PreStart();
        protected abstract void OnStart();

        /// <summary>
        /// Is called, right before the Managers DoUpdate is called.
        /// </summary>
        protected abstract void PreUpdate();
        protected abstract void OnUpdate();

        /// <summary>
        /// Is called, right before the Managers DoLateUpdate is called.
        /// </summary>
        protected abstract void PreLateUpdate();
        protected abstract void OnLateUpdate();
    }
}