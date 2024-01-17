using Example03.Items;
using System;

namespace Example03.Item
{
    public interface IReadOnlyBall
    {
        public event Action<IReadOnlyBall> Bursted;

        public BallColor Color { get; }
    }
}