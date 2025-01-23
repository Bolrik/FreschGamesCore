using UnityEngine;

namespace FreschGames.Core.ValueDataSystem
{
    public class ValueData<T> : ScriptableObject
    {
        [SerializeField] private T value;
        public T Value { get { return value; } set { this.value = value; } }

        public static implicit operator T(ValueData<T> value) => value.Value;
    }

    [System.Serializable]
    public class ValueReference<T> : ValueReference
    {
        public override object ConstantValue => throw new System.NotImplementedException();
        public override object VariableValue => throw new System.NotImplementedException();

        [field: SerializeField] public T Constant { get; set; }
        [field: SerializeField] public ValueData<T> ValueData { get; set; }

        public T Value { get => this.UseConstant ? this.Constant : this.ValueData; }

        public ValueReference()
        { }

        public ValueReference(T value)
        {
            this.UseConstant = true;
            this.Constant = value;
        }

        public static implicit operator T(ValueReference<T> reference)
        {
            return reference.Value;
        }
    }

    [System.Serializable]
    public abstract class ValueReference
    {
        [field: SerializeField] public bool UseConstant { get; set; }

        public abstract object ConstantValue { get; }
        public abstract object VariableValue { get; }
    }
}
