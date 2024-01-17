using Example03.Accounters;
using System;

namespace Example03.GameRules
{
    public class AllBallsBurstWinRule : IWinRule
    {
        private ILevelBallsCount _levelBallsCounter;

        public AllBallsBurstWinRule(ILevelBallsCount levelBallsCounter)
        {
            _levelBallsCounter = levelBallsCounter;
        }

        public event Action Won;

        public event Action Lost;

        public void Process()
        {
            if (_levelBallsCounter.BallsCount == 0)
                Won?.Invoke();
        }
    }
}