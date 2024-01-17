namespace Example03.Items
{
    public class RedBall : Ball
    {
        private readonly BallColor _ballColor = BallColor.Red;

        protected override BallColor GetInitializedBallColor()
        {
            return _ballColor;
        }
    }
}
