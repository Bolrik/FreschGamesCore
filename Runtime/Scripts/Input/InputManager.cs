using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FGC.Input
{
    public class InputManager : MonoBehaviour
    {
        private CoreInputAsset Input { get; set; }

        [SerializeField] private InputLink[] links;
        public InputLink[] Links { get { return links; } }

        InputValueUpdate InputStateUpdate { get; set; }

        private void Awake()
        {
            this.Input = new CoreInputAsset();
            this.Input.Enable();

            foreach (var link in this.Links)
            {
                InputAction action = this.Input.FindAction($"{link.Action.name}");

                if (link.Action.action == null)
                    throw new UnityException($"No Action for Input '{link.Action}' ({link.Action.name})");

                this.Link(link.Value, action);
            }
        }

        private void Link(InputValue inputValue, InputAction inputAction)
        {
            InputValueUpdate inputStateUpdate = this.InputStateUpdate;
            
            inputValue.Link(inputAction, ref inputStateUpdate);

            this.InputStateUpdate = inputStateUpdate;
        }

        private void Update()
        {
            this.InputStateUpdate?.Invoke();
        }
    }

    public delegate void InputValueUpdate();

    [System.Serializable]
    public class InputLink
    {
        [SerializeField] private InputValue value;
        public InputValue Value { get { return value; } }

        [SerializeField] private InputActionReference action;
        public InputActionReference Action { get { return action; } }
    }
}
