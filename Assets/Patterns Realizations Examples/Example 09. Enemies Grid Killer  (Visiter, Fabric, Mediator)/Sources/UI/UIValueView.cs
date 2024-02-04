using Nova;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.UI
{
    public abstract class UIValueView : MonoBehaviour
    {
        [SerializeField, Required] private TextBlock _currentValueText;

        public void UpdateView(int currentValue)
        {
            _currentValueText.Text = currentValue.ToString();
        }
    }
}
