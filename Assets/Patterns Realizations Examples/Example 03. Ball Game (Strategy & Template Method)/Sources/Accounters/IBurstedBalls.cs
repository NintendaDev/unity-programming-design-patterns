using Example03.Items;
using System.Collections.Generic;

namespace Example03.Accounters
{
    public interface IBurstedBalls
    {
        public IReadOnlyDictionary<BallColor, int> BurstedBallsStatistic { get; }
    }
}
