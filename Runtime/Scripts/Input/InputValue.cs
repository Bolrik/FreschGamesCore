using UnityEngine;
using UnityEngine.InputSystem;

namespace FGC.Input
{
    [CreateAssetMenu(fileName = "Input Value", menuName = "Data/Input/new Input Value")]
    public class InputValue : ScriptableObject
    {
        public InputAction InputAction { get; private set; }

        public bool WasPressed { get => this.InputAction.WasPressedThisFrame(); }
        public bool WasReleased { get => this.InputAction.WasReleasedThisFrame(); }
        public bool IsPressed { get => this.InputAction.IsPressed(); }

        public void Link(InputAction inputAction, ref InputValueUpdate action)
        {
            this.InputAction = inputAction;
        }
        protected virtual void OnLink(ref InputValueUpdate action) { }

        public Vector2 GetVector2() => this.InputAction.ReadValue<Vector2>();

        public T Read<T>()
            where T : struct
        {
            return this.InputAction.ReadValue<T>();
        }

        public static implicit operator float(InputValue inputValue) => inputValue.InputAction.ReadValue<float>();
    }
}