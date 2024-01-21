using UnityEngine;
using UnityEngine.InputSystem;

namespace Example03.Control
{
    public class PlayerInputEventer : AbstractInputEventer
    {
        private PlayerInput _playerInput;
        private InputAction _clickPressAction;
        private InputAction _screenPositionInput;

        public PlayerInputEventer()
        {
            _playerInput = new PlayerInput();
            _clickPressAction = _playerInput.Player.Click;
            _screenPositionInput = _playerInput.Player.ScreenPosition;
        }

        public void Enable()
        {
            _playerInput.Enable();
            _clickPressAction.performed += OnClickPress;
        }

        public void Disable()
        {
            _clickPressAction.performed -= OnClickPress;
            _playerInput.Disable();
        }

        private void OnClickPress(InputAction.CallbackContext context)
        {
            SendClickEvent(_screenPositionInput.ReadValue<Vector2>());
        }
    }
}