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
            this.Manager.DoAwake();
            this.OnAwake();
        }

        private void Start()
        {
            this.Manager.DoStart();
            this.OnStart();
        }

        private void Update()
        {
            this.Manager.DoUpdate();
            this.OnUpdate();
        }

        private void LateUpdate()
        {
            this.Manager.DoLateUpdate();
            this.OnLateUpdate();
        }

        protected abstract void OnAwake();
        protected abstract void OnStart();
        protected abstract void OnUpdate();
        protected abstract void OnLateUpdate();
    }
}