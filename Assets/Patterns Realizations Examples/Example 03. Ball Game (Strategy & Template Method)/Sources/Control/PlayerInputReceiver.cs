using Example03.Items;
using MonoUtils;
using UnityEngine;

namespace Example03.Control
{
    public class PlayerInputReceiver : InitializedMonobehaviour, IPlayerInput
    {
        private const int MaxHitInfoCount = 10;
        private PlayerInputEventer _playerInputEventer;
        private Camera _camera;
        private RaycastHit[] _raycastHits = new RaycastHit[MaxHitInfoCount];

        public void Initialize()
        {
            _playerInputEventer = new PlayerInputEventer();
            _camera = Camera.main;

            CompleteInitialization();
        }

        private void OnEnable()
        {
            _playerInputEventer.Enable();
            _playerInputEventer.ClickPressed += OnClick;
        }

        private void OnDisable()
        {
            _playerInputEventer.Disable();
            _playerInputEventer.ClickPressed -= OnClick;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void OnClick(Vector2 screenPosition)
        {
            Ray screenClickRay = _camera.ScreenPointToRay(screenPosition);

            int hitCount = Physics.RaycastNonAlloc(screenClickRay, _raycastHits);

            if (hitCount == 0)
                return;

            for (int x = 0; x < hitCount; x++)
            {
                if (_raycastHits[x].collider.gameObject.TryGetComponent(out Ball ball))
                {
                    ball.Burst();
                }
            }
        }
    }
}
