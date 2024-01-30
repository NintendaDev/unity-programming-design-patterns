using UnityEngine;

namespace Example05.UI.HealthVisualization
{
    public abstract class HealthIndicator : MonoBehaviour
    {
        public abstract void UpdateHealthVisualization(int previousValue, int currentValue, int maxValue);
    }
}