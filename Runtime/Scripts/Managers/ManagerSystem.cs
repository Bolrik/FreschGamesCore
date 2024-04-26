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
        /// The manager instance that is used within this system.
        /// </summary>
        [field: SerializeField, Header("Manager")]
        public T Manager { get; private set; }
    }
}