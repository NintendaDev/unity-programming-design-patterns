using Example03.Accounters;
using Example03.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example03.GameRules
{
    public abstract class BallGameCondition : ICondition
    {
        private IEnumerable<IReadOnlyBall> _currentBalls;

        public BallGameCondition(BallsAccounter ballsAccounter)
        {
            _currentBalls = ballsAccounter.CurrentBalls;

            foreach (IReadOnlyBall ball in _currentBalls)
                ball.Bursted += OnBallBursted;
        }

        public int CurrentBallsCount => _currentBalls.Count();

        protected IEnumerable<IReadOnlyBall> Bals => _currentBalls;

        public event Action Completed;

        protected abstract void OnBallBursted(BallColor ballColor);

        protected void SendCompleteEvent()
        {
            Completed?.Invoke();
        }

        protected bool IsExistBall(BallColor ballColor)
        {
            return _currentBalls.Where(x => x.Color == ballColor).Count() > 0;
        }

        private void OnBallBursted(IReadOnlyBall ball)
        {
            ball.Bursted -= OnBallBursted;
            OnBallBursted(ball.Color);
        }
    }
}
