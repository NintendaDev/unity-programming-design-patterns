using System;
using UnityEngine;
using Nova;

namespace Example05.UI.HealthVisualization
{
    public class TextHealthIndicator<T> : HealthIndicator<T>
        where T : struct, IFormattable
    {
        [SerializeField] private TextBlock _currentValueText;
        [SerializeField] private TextBlock _maxValueText;

        protected override void UpdateHealthVisualization()
        {
            _currentValueText.Text = HealthMediator.Health.CurrentValue.ToString();
            _maxValueText.Text = HealthMediator.Health.MaxValue.ToString();
        }
    }
}
