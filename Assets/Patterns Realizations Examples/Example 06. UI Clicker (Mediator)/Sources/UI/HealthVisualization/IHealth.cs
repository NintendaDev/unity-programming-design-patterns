using System;

namespace Example05.UI.HealthVisualization
{
    public interface IHealth
    {
        public int MaxValue { get; }

        public int CurrentValue { get; }

        public event Action<int, int> Changed;
    }
}