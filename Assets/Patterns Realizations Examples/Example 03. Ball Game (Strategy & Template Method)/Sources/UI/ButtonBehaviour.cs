using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03
{
    public abstract class ButtonBehaviour : MonoBehaviour
    {
        [SerializeField, Required] private Button _button;

        private void OnEnable()
        {
            _button.OnClicked.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.OnClicked.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}
