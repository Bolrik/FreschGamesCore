using System;
using UnityEngine;

namespace FreschGames.Core.Misc
{
    [System.Serializable]
    public class Range<T>
        where T : IComparable<T>
    {
        [field: SerializeField] public T Min { get; private set; }
        [field: SerializeField] public T Max { get; private set; }

        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
            {
                throw new ArgumentException("min must be less than or equal to max");
            }

            this.Min = min;
            this.Max = max;
        }

        public void Eval(T value, out T validValue)
        {
            if (value.CompareTo(this.Min) < 0)
            {
                validValue = this.Min;
            }
            else if (value.CompareTo(this.Max) > 0)
            {
                validValue = this.Max;
            }
            else
            {
                validValue = value;
            }
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(this.Min) >= 0 && value.CompareTo(this.Max) <= 0;
        }

        #region <= / >=
        public static bool operator <=(Range<T> range, T value)
        {
            bool isValid = range.IsInRange(value);
            int compare = range.Max.CompareTo(value);
            return compare <= 0 || isValid;
        }

        public static bool operator <=(T value, Range<T> range)
        {
            return range >= value;
        }

        public static bool operator >=(Range<T> range, T value)
        {
            bool isValid = range.IsInRange(value);
            int compare = range.Min.CompareTo(value);
            return compare >= 0 || isValid;
        }

        public static bool operator >=(T value, Range<T> range)
        {
            return range <= value;
        }
        #endregion

        #region < / >
        public static bool operator <(Range<T> range, T value)
        {
            int compare = range.Max.CompareTo(value);
            return compare < 0;
        }

        public static bool operator <(T value, Range<T> range)
        {
            return range > value;
        }

        public static bool operator >(Range<T> range, T value)
        {
            int compare = range.Min.CompareTo(value);
            return compare > 0;
        }

        public static bool operator >(T value, Range<T> range)
        {
            return range < value;
        }
        #endregion

        #region == / !=
        public static bool operator ==(Range<T> range, T value)
        {
            return range.IsInRange(value);
        }

        public static bool operator ==(T value, Range<T> range)
        {
            return range.IsInRange(value);
        }

        public static bool operator !=(Range<T> range, T value)
        {
            return !range.IsInRange(value);
        }

        public static bool operator !=(T value, Range<T> range)
        {
            return !range.IsInRange(value);
        }
        #endregion
    }
}