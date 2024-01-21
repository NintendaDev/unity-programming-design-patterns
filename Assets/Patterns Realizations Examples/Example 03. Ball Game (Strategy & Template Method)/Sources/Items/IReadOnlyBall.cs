using System;

namespace Example03.Items
{
    public interface IReadOnlyBall
    {
        public event Action<IReadOnlyBall> Bursted;

        public BallColor Color { get; }
    }
}