using MonoUtils;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI
{
    public abstract class UIButton : InitializedMonobehaviour
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

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        protected abstract void OnButtonClick();
    }
}
