using Example03.Accounters;
using Example03.Items;
using System.Linq;

namespace Example03.GameRules
{
    public class OneColorBallsBurstLoseCondition : BallGameCondition
    {
        private BurstBallsAccounter _burstBallsAccounter;
        private BallColor _winColor;
        private bool _isInitializedWinColor;

        public OneColorBallsBurstLoseCondition(BallsAccounter ballsAccounter, BurstBallsAccounter burstBallsAccounter) : base(ballsAccounter)
        {
            _burstBallsAccounter = burstBallsAccounter;
        }

        public override void Restart()
        {
            base.Restart();
            _isInitializedWinColor = false;
        }

        public void SetWinColor(BallColor winColor)
        {
            _winColor = winColor;
            _isInitializedWinColor = true;
        }

        protected override void OnBallBursted(BallColor ballColor)
        {
            if (_isInitializedWinColor == false)
                return;

            if (IsOnlyOneColorBurst() == false)
                SendCompleteEvent();
        }

        private bool IsOnlyOneColorBurst()
        {
            int loseBurstColorsCount = _burstBallsAccounter.BurstedBallsStatistic
                .Where(x => x.Key != _winColor)
                .Sum(x => x.Value);

            return loseBurstColorsCount == 0;
        }
    }
}
