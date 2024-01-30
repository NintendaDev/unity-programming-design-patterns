using System;
using UnityEngine;
using Nova;

namespace Example05.UI.HealthVisualization
{
    public class TextHealthIndicator : HealthIndicator
    {
        [SerializeField] private TextBlock _currentValueText;
        [SerializeField] private TextBlock _maxValueText;

        public override void UpdateHealthVisualization(int previousValue, int currentValue, int maxValue)
        {
            _currentValueText.Text = currentValue.ToString();
            _maxValueText.Text = maxValue.ToString();
        }
    }
}
