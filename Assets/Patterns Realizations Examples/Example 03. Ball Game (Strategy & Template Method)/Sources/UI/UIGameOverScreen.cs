using Example03.Core;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.UI
{
    public class UIGameOverScreen : UIScreen, IRestart
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Button _mainMenuButton;

        private UIStartScreen _startScreen;

        [Inject]
        private void Construct(UIStartScreen startScreen)
        {
            _startScreen = startScreen;

            CompleteInitialization();
        }

        private void OnEnable()
        {
            _mainMenuButton.OnClicked.AddListener(OnManiMenuButtonClick);
        }

        private void OnDisable()
        {
            _mainMenuButton.OnClicked.RemoveListener(OnManiMenuButtonClick);
        }

        public void Restart()
        {
            Disable();
        }

        private void OnManiMenuButtonClick()
        {
            gameObject.SetActive(false);
            _startScreen.Enable();
        }
    }
}
