using Example03.Item;
using Example03.Items;
using System.Collections.Generic;

namespace Example03.Accounters
{
    public interface ILevelBalls : ILevelBallsCount
    {
        public IReadOnlyList<IReadOnlyBall> CurrentBalls { get; }

        public IReadOnlyDictionary<BallColor, int> BallsColorStatistic { get; }
    }
}
