using Example02.Environment;
using Nova;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Example02.Control
{
    public class PlayerInputEventer : AbstractInputEventer
    {
        private const int MaxRaycastHits = 10;
        private const int UIBlockHitsThreshold = 1;
        private PlayerInput _playerInput;
        private InputAction _movePressAction;
        private InputAction _screenPositionInput;
        private Camera _camera;
        private RaycastHit[] _raycastHits = new RaycastHit[MaxRaycastHits];
        private List<UIBlockHit> _uiBlockHits = new List<UIBlockHit>();

        public PlayerInputEventer()
        {
            _playerInput = new PlayerInput();
            _movePressAction = _playerInput.Player.Move;
            _screenPositionInput = _playerInput.Player.ScreenPosition;
            _camera = Camera.main;
        }

        public void Enable()
        {
            _playerInput.Enable();
            _movePressAction.performed += OnMovePress;
        }

        public void Disable()
        {
            _movePressAction.performed -= OnMovePress;
            _playerInput.Disable();
        }

        private void OnMovePress(InputAction.CallbackContext context)
        {
            Vector2 screenPosition = _screenPositionInput.ReadValue<Vector2>();
            Ray ray = _camera.ScreenPointToRay(screenPosition);

            if (HasUI(ray))
                return;

            int hitsCount = Physics.RaycastNonAlloc(ray, _raycastHits);

            if (hitsCount == 0)
                return;

            for (int x = 0; x < hitsCount; x++)
            {
                if (_raycastHits[x].collider.gameObject.TryGetComponent(out Ground _))
                {
                    SenMoveEvent(_raycastHits[x].point);
                    return;
                }
            }
        }

        private bool HasUI(Ray ray)
        {
            Interaction.RaycastAll(ray, _uiBlockHits);

            return _uiBlockHits.Count > UIBlockHitsThreshold;
        }
    }
}