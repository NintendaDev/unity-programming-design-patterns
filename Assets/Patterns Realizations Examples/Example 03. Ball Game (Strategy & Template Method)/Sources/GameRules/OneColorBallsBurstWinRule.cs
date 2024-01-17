using Example03.Accounters;
using Example03.GameRules;
using Example03.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example03
{
    public class OneColorBallsBurstWinRule : IWinRule
    {
        private const int MaxBurstBallsColorCount = 1;
        private ILevelBalls _levelBalls;
        private IBurstedBalls _burstedBalls;
        private BallColor _winColor;
        private bool _isInitializedWinColor;
        private bool _isEndGame;

        public OneColorBallsBurstWinRule(ILevelBalls levelBalls, IBurstedBalls burstedBalls)
        {
            _levelBalls = levelBalls;
            _burstedBalls = burstedBalls;
        }

        public event Action Won;

        public event Action Lost;

        public void Process()
        {
            if (_isEndGame)
                return;

            if (_isInitializedWinColor == false)
            {
                try
                {
                    if (TryInitializeWinColor() == false)
                        return;
                }
                catch (GreatThenOneBurstColors exception)
                {
                    StartLoseBehaviour();
                    return;
                }
            }

            if (IsOnlyOneColorBurst() == false)
            {
                StartLoseBehaviour();
                return;
            }

            if (IsOverWinColorBalls())
                StartWinBehaviour();
        }

        private bool TryInitializeWinColor()
        {
            IEnumerable<KeyValuePair<BallColor, int>> balls = _burstedBalls.BurstedBallsStatistic.Where(x => x.Value > 0);

            if (balls.Count() == 0)
                return false;

            if (balls.Count() > MaxBurstBallsColorCount)
                throw new GreatThenOneBurstColors();

            _winColor = balls.Select(x => x.Key).FirstOrDefault();
            _isInitializedWinColor = true;

            return true;
        }

        private void StartLoseBehaviour()
        {
            _isEndGame = true;
            Lost?.Invoke();
        }

        private bool IsOnlyOneColorBurst()
        {
            int loseBurstColorsCount = _burstedBalls.BurstedBallsStatistic
                .Where(x => x.Key != _winColor)
                .Sum(x => x.Value);

            return loseBurstColorsCount == 0;
        }

        private bool IsOverWinColorBalls()
        {
            return _levelBalls.BallsColorStatistic[_winColor] == 0;
        }

        private void StartWinBehaviour()
        {
            _isEndGame = true;
            Won?.Invoke();
        }

        class GreatThenOneBurstColors : Exception
        {
            public GreatThenOneBurstColors() : base(string.Empty) 
            {
            }
        }
    }
}
