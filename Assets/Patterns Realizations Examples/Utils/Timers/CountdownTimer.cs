namespace Utils.Timers
{
    public class CountdownTimer : Timer
    {
        private float _startValue;

        public CountdownTimer(float startValue) : base() 
        {
            _startValue = startValue;
        }

        public override void Start()
        {
            Start(_startValue);
        }
    }
}