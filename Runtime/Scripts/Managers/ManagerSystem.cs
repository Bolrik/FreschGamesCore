using FreschGames.Core.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreschGames.Core.Managers
{
    /// <summary>
    /// A base abstract class for manager components that handle specific functionalities
    /// </summary>
    /// <typeparam name="T">The type of manager to be used with this component.</typeparam>
    public abstract class ManagerSystem<T> : MonoBehaviour where T : Manager
    {
        /// <summary>
        /// The manager instance that is used with this component.
        /// </summary>
        [field: SerializeField, Header("Manager")]
        public T Manager { get; private set; }

        /// <summary>
        /// Called when the component is first instantiated.
        /// </summary>
        private void Awake()
        {
            this.PreAwake();
            this.Manager.SystemAwake();
            this.PostAwake();
        }
        
        /// <summary>
        /// Called when the component is first instantiated.
        /// </summary>
        private void Start()
        {
            this.PreStart();
            this.Manager.SystemStart();
            this.PostStart();
        }

        /// <summary>
        /// Called when the component is enabled.
        /// </summary>
        private void OnEnable()
        {
            this.PreOnEnable();
            this.Manager.SystemEnable();
            this.PostOnEnable();
        }

        /// <summary>
        /// Called when the component is disabled.
        /// </summary>
        private void OnDisable()
        {
            this.PreOnDisable();
            this.Manager.SystemDisable();
            this.PostOnDisable();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update()
        {
            this.PreUpdate();
            this.Manager.SystemUpdate();
            this.PostUpdate();
        }

        /// <summary>
        /// Called every frame, after all Update functions have been called.
        /// </summary>
        private void LateUpdate()
        {
            this.PreLateUpdate();
            this.Manager.SystemLateUpdate();
            this.PostLateUpdate();
        }


        /// <summary>
        /// Called before the Awake function.
        /// </summary>
        protected virtual void PreAwake() { }

        /// <summary>
        /// Called after the Awake function.
        /// </summary>
        protected virtual void PostAwake() { }

        /// <summary>
        /// Called before the Start function.
        /// </summary>
        protected virtual void PreStart() { }

        /// <summary>
        /// Called after the Start function.
        /// </summary>
        protected virtual void PostStart() { }

        /// <summary>
        /// Called before the Update function.
        /// </summary>
        protected virtual void PreUpdate() { }

        /// <summary>
        /// Called after the Update function.
        /// </summary>
        protected virtual void PostUpdate() { }

        /// <summary>
        /// Called before the LateUpdate function.
        /// </summary>
        protected virtual void PreLateUpdate() { }

        /// <summary>
        /// Called after the LateUpdate function.
        /// </summary>
        protected virtual void PostLateUpdate() { }

        /// <summary>
        /// Called before the OnDisable function.
        /// </summary>
        protected virtual void PreOnDisable() { }

        /// <summary>
        /// Called after the OnDisable function.
        /// </summary>
        protected virtual void PostOnDisable() { }

        /// <summary>
        /// Called before the OnEnable function.
        /// </summary>
        protected virtual void PreOnEnable() { }

        /// <summary>
        /// Called after the OnEnable function.
        /// </summary>
        protected virtual void PostOnEnable() { }
    }
}