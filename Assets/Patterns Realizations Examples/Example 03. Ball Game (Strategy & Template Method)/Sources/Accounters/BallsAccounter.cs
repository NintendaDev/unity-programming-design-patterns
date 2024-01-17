using Example03.Item;
using Example03.Items;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Specifications;
using Sirenix.OdinInspector;

namespace Example03.Accounters
{
    public class BallsAccounter : MonoBehaviour, ILevelBalls
    {
        private List<Ball> _allLevelBalls = new();
        private List<IReadOnlyBall> _currentBalls = new();
        private Dictionary<BallColor, int> _ballsColorStatistic = new();
        private ISpecification<int> _colorStatisticSpecification = new IntGreatOrEqualZeroSpecification();

        public IReadOnlyList<IReadOnlyBall> CurrentBalls => _currentBalls;

        public IReadOnlyDictionary<BallColor, int> BallsColorStatistic => _ballsColorStatistic;

        [ShowInInspector, ReadOnly]
        public int BallsCount => _currentBalls.Count;

        public void Initialize()
        {
            _ballsColorStatistic.Clear();
            _currentBalls.Clear();

            if (_allLevelBalls.Count > 0)
            {
                foreach (Ball ball in _allLevelBalls)
                    ball.Bursted -= OnBallBursted;
            }
            else
            {
                _allLevelBalls = GetComponentsInChildren<Ball>().ToList();
            }

            foreach (Ball ball in _allLevelBalls)
            {
                ball.Initialize();

                ball.Bursted += OnBallBursted;

                if (BallsColorStatistic.ContainsKey(ball.Color) == false)
                    _ballsColorStatistic[ball.Color] = 0;

                _ballsColorStatistic[ball.Color]++;

                _currentBalls.Add(ball);
            }
        }

        private void OnBallBursted(IReadOnlyBall ball)
        {
            ball.Bursted -= OnBallBursted;
            _ballsColorStatistic[ball.Color]--;

            if (_colorStatisticSpecification.IsSatisfiedBy(BallsColorStatistic[ball.Color]) == false)
                throw new System.ArgumentOutOfRangeException("The ball color statistics do not match the specification");

            _currentBalls.Remove(ball);
        }
    }
}