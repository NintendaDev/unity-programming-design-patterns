using Example03.Items;
using UnityEngine;

namespace Example02.Control
{
    public class PlayerInputReceiver : MonoBehaviour
    {
        private const int MaxHitInfoCount = 10;
        private PlayerInputEventer _playerInputEventer;
        private Camera _camera;
        private RaycastHit[] _raycastHits = new RaycastHit[MaxHitInfoCount];

        public void Initialize()
        {
            _playerInputEventer = new PlayerInputEventer();
            _camera = Camera.main;
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
