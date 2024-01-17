namespace Example03.Items
{
    public class GreenBall : Ball
    {
        private readonly BallColor _ballColor = BallColor.Green;

        protected override BallColor GetInitializedBallColor()
        {
            return _ballColor;
        }
    }
}
