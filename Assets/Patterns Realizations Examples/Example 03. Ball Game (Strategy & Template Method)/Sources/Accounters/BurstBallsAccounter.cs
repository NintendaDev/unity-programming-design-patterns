using Example03.Item;
using Example03.Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Example03.Accounters
{
    public class BurstBallsAccounter : MonoBehaviour, IBurstedBalls
    {
        private IEnumerable<IReadOnlyBall> _balls;
        private Dictionary<BallColor, int> _burstedBallsStatistics = new();

        public event Action<BallColor> BallBursted;

        public IReadOnlyDictionary<BallColor, int> BurstedBallsStatistic => _burstedBallsStatistics;

        public void Initialize(IEnumerable<IReadOnlyBall> balls)
        {
            _burstedBallsStatistics.Clear();

            if (_balls != null)
            {
                foreach (IReadOnlyBall ballBurstEvent in _balls)
                    ballBurstEvent.Bursted -= OnBallBurst;
            }

            _balls = balls;

            foreach (IReadOnlyBall ball in _balls)
                ball.Bursted += OnBallBurst;
        }

        private void OnBallBurst(IReadOnlyBall ball)
        {
            ball.Bursted -= OnBallBurst;
            Account(ball.Color);
            BallBursted?.Invoke(ball.Color);
        }

        private void Account(BallColor ballColor)
        {
            if (_burstedBallsStatistics.ContainsKey(ballColor) == false)
                _burstedBallsStatistics[ballColor] = 0;

            _burstedBallsStatistics[ballColor]++;
        }
    }
}
