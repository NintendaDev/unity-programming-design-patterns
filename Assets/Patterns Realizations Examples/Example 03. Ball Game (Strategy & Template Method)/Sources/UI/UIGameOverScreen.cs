using Nova;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03.UI
{
    public class UIGameOverScreen : UIScreen
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Button _mainMenuButton;

        private UIStartScreen _startScreen;

        public void Initialize(UIStartScreen startScreen)
        {
            _startScreen = startScreen;
        }

        private void OnEnable()
        {
            _mainMenuButton.OnClicked.AddListener(OnManiMenuButtonClick);
        }

        private void OnDisable()
        {
            _mainMenuButton.OnClicked.RemoveListener(OnManiMenuButtonClick);
        }

        private void OnManiMenuButtonClick()
        {
            gameObject.SetActive(false);
            _startScreen.Enable();
        }
    }
}
