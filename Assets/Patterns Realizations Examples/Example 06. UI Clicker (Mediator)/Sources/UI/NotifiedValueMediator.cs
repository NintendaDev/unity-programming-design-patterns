using Example06.Core;
using System;

namespace Example06.UI
{
    public class NotifiedValueMediator : IDisposable
    {
        private IReadOnlyNotifiedValue _notifiedValue;
        private UIValueText<int> _uiValue;

        public NotifiedValueMediator(IReadOnlyNotifiedValue notifiedValue, UIValueText<int> uiValue)
        {
            _notifiedValue = notifiedValue;
            _uiValue = uiValue;

            SetValueText(_notifiedValue.Value);

            _notifiedValue.Changed += OnValueChanged;
        }

        public void Dispose()
        {
            _notifiedValue.Changed -= OnValueChanged;
        }

        private void SetValueText(int currentValue)
        {
            _uiValue.SetValueText(currentValue);
        }

        private void OnValueChanged(int previousValue, int currentValue)
        {
            SetValueText(currentValue);
        }
    }
}
