using Example03.Core;
using Example03.Items;
using System.Collections.Generic;

namespace Example03.Accounters
{
    public class BurstBallsAccounter : IRestart
    {
        private IEnumerable<IReadOnlyBall> _currentBalls;
        private Dictionary<BallColor, int> _burstedBallsStatistics = new();

        public BurstBallsAccounter(BallsAccounter ballsAccounter)
        {
            _currentBalls = ballsAccounter.CurrentBalls;

            foreach (IReadOnlyBall ball in _currentBalls)
                ball.Bursted += OnBallBurst;
        }

        public IReadOnlyDictionary<BallColor, int> BurstedBallsStatistic => _burstedBallsStatistics;

        public void Restart()
        {
            _burstedBallsStatistics.Clear();

            foreach (IReadOnlyBall ball in _currentBalls)
            {
                ball.Bursted -= OnBallBurst;
                ball.Bursted += OnBallBurst;
            }
        }

        private void OnBallBurst(IReadOnlyBall ball)
        {
            ball.Bursted -= OnBallBurst;
            Account(ball.Color);
        }

        private void Account(BallColor ballColor)
        {
            if (_burstedBallsStatistics.ContainsKey(ballColor) == false)
                _burstedBallsStatistics[ballColor] = 0;

            _burstedBallsStatistics[ballColor]++;
        }
    }
}
