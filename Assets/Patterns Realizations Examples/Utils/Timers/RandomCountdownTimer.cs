using UnityEngine;

namespace Utils.Timers
{
    public class RandomCountdownTimer : Timer
    {
        private float _startValue;
        private float _minValue;
        private float _maxValue;

        public RandomCountdownTimer(float minValue, float endValue) : base()
        {
            _minValue = minValue;
            _maxValue = endValue;
        }

        public override void Start()
        {
            _startValue = Random.Range(_minValue, _maxValue);
            Start(_startValue);
        }
    }
}
