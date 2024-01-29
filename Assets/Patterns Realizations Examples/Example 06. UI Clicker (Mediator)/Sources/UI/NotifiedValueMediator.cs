using Example06.Core;
using System;

namespace Example06.UI
{
    public class NotifiedValueMediator : IDisposable
    {
        private IReadOnlyNotifiedValue _notifiedValue;

        public NotifiedValueMediator(IReadOnlyNotifiedValue notifiedValue)
        {
            _notifiedValue = notifiedValue;
            _notifiedValue.Changed += OnValueChanged;
        }

        public event Action<int> Changed;

        public int Value => _notifiedValue.Value;

        public void Dispose()
        {
            _notifiedValue.Changed -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            Changed?.Invoke(value);
        }
    }
}
