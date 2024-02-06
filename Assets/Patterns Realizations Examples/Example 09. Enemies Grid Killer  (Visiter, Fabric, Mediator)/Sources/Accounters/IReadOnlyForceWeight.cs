using System;

namespace Example09.Accounters
{
    public interface IReadOnlyForceWeight
    {
        public event Action<int, int> Changed;

        public int Value { get; }

        public int MaxValue { get; }
    }
}