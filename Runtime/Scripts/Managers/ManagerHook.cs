using UnityEngine;

namespace FreschGames.Core.Managers
{
    /// <summary>
    /// A component used to keep a Manager (Scriptable Object) active even when scenes change
    /// </summary>
    public class ManagerHook : MonoBehaviour
    {
        /// <summary>
        /// Gets the Manager instance.
        /// </summary>
        public Manager Manager { get; private set; }

        /// <summary>
        /// Sets the Manager instance.
        /// </summary>
        /// <param name="manager">The Manager instance to set.</param>
        public void Set(Manager manager)
        {
            this.Manager = manager;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}