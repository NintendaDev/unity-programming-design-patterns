namespace Example03.Items
{
    public class WhiteBall : Ball
    {
        private readonly BallColor _ballColor = BallColor.White;

        protected override BallColor GetInitializedBallColor()
        {
            return _ballColor;
        }
    }
}