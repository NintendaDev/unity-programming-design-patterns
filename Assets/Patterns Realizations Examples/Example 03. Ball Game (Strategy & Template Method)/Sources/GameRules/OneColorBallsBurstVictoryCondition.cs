using Example03.Accounters;
using Example03.Items;

namespace Example03.GameRules
{
    public class OneColorBallsBurstVictoryCondition : BallGameCondition
    {
        private BallColor _winColor;
        private bool _isInitializedWinColor;
        private OneColorBallsBurstLoseCondition _oneColorBallBurstLoseCondition;

        public OneColorBallsBurstVictoryCondition(BallsAccounter ballsAccounter, 
            OneColorBallsBurstLoseCondition oneColorBallBurstLoseCondition) : base(ballsAccounter)
        {
            _oneColorBallBurstLoseCondition = oneColorBallBurstLoseCondition;
        }

        protected override void OnBallBursted(BallColor ballColor)
        {
            InitializeWinColor(ballColor);

            if (IsExistBall(_winColor) == false)
                SendCompleteEvent();
        }

        private void InitializeWinColor(BallColor ballColor)
        {
            if (_isInitializedWinColor)
                return;

            _winColor = ballColor;
            _oneColorBallBurstLoseCondition.SetWinColor(_winColor);

            _isInitializedWinColor = true;
        }
    }
}