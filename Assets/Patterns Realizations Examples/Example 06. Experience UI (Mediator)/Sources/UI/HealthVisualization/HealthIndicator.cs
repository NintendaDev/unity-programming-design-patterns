using MonoUtils;
using System;

namespace Example05.UI.HealthVisualization
{
    public abstract class HealthIndicator<T> : InitializedMonobehaviour
        where T : struct, IFormattable
    {
        protected HealthMediator<T> HealthMediator { get; private set; }

        public void Initialize(HealthMediator<T> healthMediator)
        {
            HealthMediator = healthMediator;
            IsInitialized = true;
        }

        private void Start()
        {
            UpdateHealthVisualization();
        }

        private void OnEnable()
        {
            HealthMediator.Changed += OnHealthChange;
        }

        private void OnDisable()
        {
            HealthMediator.Changed -= OnHealthChange;
        }

        protected abstract void UpdateHealthVisualization();

        private void OnHealthChange(T value)
        {
            UpdateHealthVisualization();
        }
    }
}