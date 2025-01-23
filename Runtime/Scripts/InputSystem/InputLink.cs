using UnityEngine;
using UnityEngine.InputSystem;

namespace FreschGames.Core.InputSystem
{
    [System.Serializable]
    public class InputLink
    {
        [SerializeField] private InputValue value;
        public InputValue Value { get { return value; } }

        [SerializeField] private InputActionReference action;
        public InputActionReference Action { get { return action; } }
    }
}
