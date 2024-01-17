using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.UI
{
    public abstract class UIButtonAbstract : MonoBehaviour
    {
        [SerializeField, Required] private Button _button;

        private void OnEnable()
        {
            _button.OnClicked.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.OnClicked.RemoveListener(OnButtonClick);
        }

        protected abstract void OnButtonClick();
    }
}
