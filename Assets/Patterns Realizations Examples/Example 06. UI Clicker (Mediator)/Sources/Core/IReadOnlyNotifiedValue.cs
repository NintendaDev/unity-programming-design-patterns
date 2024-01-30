using System;

namespace Example06.Core
{
    public interface IReadOnlyNotifiedValue
    {
        public event Action<int, int> Changed;

        public int Value { get; }
    }
}
