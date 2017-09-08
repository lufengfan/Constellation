using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace αστερισμό
{
    public struct Box<T> : IEquatable<Box<T>>
    {
        private T value;
        private bool hasValue;

        public T Value
        {
            get
            {
                if (this.hasValue)
                    return this.value;
                else
                    throw new InvalidOperationException("不含有值。");
            }
        }

        public bool HasValue => this.hasValue;

        public static Box<T> NonValue => new Box<T>();

        public Box(T value)
        {
            this.value = value;
            this.hasValue = true;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Box<T> && this.Equals((Box<T>)obj);
        }

        public bool Equals(Box<T> other)
        {
            return (this.hasValue == other.hasValue && EqualityComparer<T>.Default.Equals(this.value, other.value));
        }

        public override int GetHashCode()
        {
            if (this.hasValue)
                return this.value.GetHashCode();
            else
                return 0;
        }

        public T GetValueOrDefault()
        {
            return this.value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            if (this.hasValue)
                return this.value;
            else
                return defaultValue;
        }

        public override string ToString()
        {
            if (this.hasValue)
                return this.value.ToString();
            else
                return string.Empty;
        }

        public static explicit operator T(Box<T> value)
        {
            return value.Value;
        }

        public static implicit operator Box<T>(T value)
        {
            return new Box<T>(value);
        }
    }
}
