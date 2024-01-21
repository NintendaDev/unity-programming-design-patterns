using Example03.Accounters;
using Example03.Items;

namespace Example03.GameRules
{
    public class AllBallsBurstVictoryCondition : BallGameCondition
    {
        public AllBallsBurstVictoryCondition(BallsAccounter ballsAccounter) : base(ballsAccounter)
        {
        }

        protected override void OnBallBursted(BallColor ballColor)
        {
            if (CurrentBallsCount == 0)
                SendCompleteEvent();
        }
    }
}
